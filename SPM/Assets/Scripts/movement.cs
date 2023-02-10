using UnityEngine;
using Cinemachine;
using TMPro;
using System.Collections;
public class movement : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private CinemachineBasicMultiChannelPerlin noise;
    [SerializeField] private float speed;
    [SerializeField] private float movent;
    public int coins;
    [SerializeField] private int mycoin;
    [SerializeField] private TMP_Text cointxt;
    [SerializeField] private new Collider2D collider;
    [SerializeField] private GameObject gamovr;
    [SerializeField] private GameObject exp;
    [SerializeField] private GameObject gen;
    [SerializeField] private GameObject canv;
    [SerializeField] private AudioClip gameover;
    [SerializeField] private AudioClip dead;
    [SerializeField] private AudioClip coinsnd;
    [SerializeField] private AudioClip invisnd;
    [SerializeField] private GameObject pan;
    [SerializeField] private GameObject lbtn;
    [SerializeField] private GameObject sh;
    [SerializeField] private bool invis;
    void Start()
    {
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        mycoin = PlayerPrefs.GetInt("Coins", 0);
    }
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movent * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        if (coins < 0)
        { 
            coins = 0;
            cointxt.text = "Coins: " + coins;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            Destroy(collider.gameObject);
            gen.GetComponent<AudioSource>().PlayOneShot(coinsnd);
            coins += 1;
            cointxt.text = "Coins: " + coins;
            Debug.Log("coin");
        }
        else if (collider.gameObject.tag == "Shield" && invis == false)
        {
            Destroy(collider.gameObject);
            StartCoroutine(sped());
        }
        else if (collider.gameObject.tag == "Shield" && invis == true)
        {}
        else if (collider.gameObject.tag == "hexagon" && invis == true)
        {
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "hexagon" && invis == false)
        {
            StartCoroutine(boom());
        }
    }
    IEnumerator boom()
    {
        speed = 0f;
        Destroy(pan);
        Destroy(lbtn);
        Instantiate(exp, gameObject.transform);
        canv.GetComponent<AudioSource>().Stop();
        gen.GetComponent<AudioSource>().PlayOneShot(dead);
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1;
        yield return new WaitForSeconds(0.1f);
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
        gen.GetComponent<AudioSource>().PlayOneShot(gameover);
        gamovr.SetActive(true);
        Time.timeScale = 0;
    }
    IEnumerator sped()
    {
        Instantiate(sh, gameObject.transform);
        gen.GetComponent<AudioSource>().PlayOneShot(invisnd);
        invis = true;
        yield return new WaitForSeconds(30f);
        invis = false;
    }
    public void up()
    {
        movent = 1;
    }
    public void down()
    {
        movent = -1;
    }
    public void movnclr()
    {
        movent = 0;
    }
}
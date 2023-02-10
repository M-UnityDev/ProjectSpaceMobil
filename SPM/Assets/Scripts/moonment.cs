using UnityEngine;
using Cinemachine;
using TMPro;
using System.Collections;
public class moonment : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private CinemachineBasicMultiChannelPerlin noise;
    [SerializeField] private float speed = 300f;
    [SerializeField] private float movent = 0f;
    [SerializeField] private new Collider2D collider;
    [SerializeField] private TMP_Text cointxt;
    [SerializeField] private GameObject exp;
    [SerializeField] private GameObject gen;
    public movement earth;
    [SerializeField] private AudioClip dead;
    void Start()
    {
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movent * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "hexagon")
        {StartCoroutine(boom());}
    }
    IEnumerator boom()
    {
        Instantiate(exp, gameObject.transform);
        speed = 0f;
        earth.coins = earth.coins - 10;
        cointxt.text = "Coins: " + earth.coins;
        Debug.Log("-10");
        gen.GetComponent<AudioSource>().PlayOneShot(dead);
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1;
        yield return new WaitForSeconds(0.1f);
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
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
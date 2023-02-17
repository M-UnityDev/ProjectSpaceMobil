using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
public class Generator : MonoBehaviour
{
    public float scr;
    public float spwnrt = 2f;
    public movement earth;
    public int mycoin;
    [SerializeField] private GameObject hexpref;
    [SerializeField] private GameObject coinpref;
    [SerializeField] private GameObject spdpref;
    [SerializeField] private GameObject pan;
    [SerializeField] private GameObject cont;
    [SerializeField] private GameObject canv;
    private bool pause = false;
    [SerializeField] private float nxttimetispwn = 0f;
    [SerializeField] private TMP_Text score;
    [SerializeField] private Vector3 center;
    [SerializeField] private Vector3 hexagon;
    [SerializeField] private AudioClip auc;
    void Start()
    {
        StartCoroutine(coin());
        StartCoroutine(spdspwn());
        mycoin = PlayerPrefs.GetInt("Coins", 0);
    }
    void Update()
    {
        canv.GetComponent<AudioSource>().volume = pause ? 0.25f : 1f;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            pan.SetActive(pause);
            Time.timeScale = pause ? 0 : 1;
        }
        if (Time.time >= nxttimetispwn)
        {
            Vector3 hexpos = center + new Vector3(0, 0, 750);
            Instantiate(hexpref, hexpos, Quaternion.identity);
            nxttimetispwn = Time.time + 1f * spwnrt;
            scr += 1;
            score.text = scr.ToString();
        }
    }
    public void extbtn()
    {
        GetComponent<AudioSource>().PlayOneShot(auc);
        Time.timeScale = 1;
        SceneManager.LoadScene("Levels");
        PlayerPrefs.SetInt("Coins", mycoin + earth.coins);
    }
    public void resumbtn()
    {
        GetComponent<AudioSource>().PlayOneShot(auc);
        pause = !pause;
        pan.SetActive(pause);
        Time.timeScale = pause ? 0 : 1;
    }
    public void restartbtn()
    {
        GetComponent<AudioSource>().PlayOneShot(auc);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Coins", mycoin + earth.coins);
        SceneManager.LoadScene("Game");
    }
    IEnumerator coin()
    {
        Vector2 pos = center + new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f));
        yield return new WaitForSeconds(5f);
        Instantiate(coinpref, pos, Quaternion.identity);
        StartCoroutine(coin());
    }
    IEnumerator spdspwn()
    {
        Vector2 pos = center + new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f));
        yield return new WaitForSeconds(30f);
        Instantiate(spdpref, pos, Quaternion.identity);
        StartCoroutine(spdspwn());
    }
    public void puse()
    {
        pause = !pause;
        pan.SetActive(pause);
        cont.SetActive(!pause);
        Time.timeScale = pause ? 0 : 1;
    }
}
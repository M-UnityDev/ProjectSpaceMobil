using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject gen;
    [SerializeField] private AudioClip aus;
    public void strgame()
    {
        gen.GetComponent<AudioSource>().PlayOneShot(aus);
        SceneManager.LoadScene("Game");
    }
    public void extgame()
    {
        gen.GetComponent<AudioSource>().PlayOneShot(aus);
        Application.Quit();
    }
    public void optionbtn()
    {
        gen.GetComponent<AudioSource>().PlayOneShot(aus);
        SceneManager.LoadScene("options");
    }
    public void extoptionbtn()
    {
        gen.GetComponent<AudioSource>().PlayOneShot(aus);
        SceneManager.LoadScene("MainMenu");
    }
    public void guidebtn()
    {
        gen.GetComponent<AudioSource>().PlayOneShot(aus);
        SceneManager.LoadScene("guide");
    }
    public void levelbtn()
    {
        gen.GetComponent<AudioSource>().PlayOneShot(aus);
        SceneManager.LoadScene("Planets");
    }
    public void modebtn()
    {
        gen.GetComponent<AudioSource>().PlayOneShot(aus);
        SceneManager.LoadScene("Levels");
    }
    public void onebtn()
    {
        gen.GetComponent<AudioSource>().PlayOneShot(aus);
        SceneManager.LoadScene("GameWithOneButton");
    }
}

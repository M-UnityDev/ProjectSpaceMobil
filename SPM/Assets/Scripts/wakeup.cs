using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class wakeup : MonoBehaviour
{
    public GameObject music;
    public GameObject sfx;
    public Toggle togglesfx;
    public Toggle togglemusic;
    public Toggle togglepostproc;
    [SerializeField] private PostProcessVolume Volume;
    [SerializeField] private AudioClip snd;
    public bool mutingsfx = false;
    public bool mutingmusic = false;
    public bool mutingpostproc = true;
    public void sfxsnd()
    {
        if (togglesfx.isOn == false)
        {
            sfx.GetComponent<AudioSource>().PlayOneShot(snd);
        }
    }
    void Start()
    {
        mutingsfx = intToBool(PlayerPrefs.GetInt("MuteSFX", 0));
        mutingmusic = intToBool(PlayerPrefs.GetInt("MuteMusic", 0));
        mutingpostproc = intToBool(PlayerPrefs.GetInt("MutePostProc", 0));
        togglemusic.isOn = mutingmusic;
        togglesfx.isOn = mutingsfx;
        togglepostproc.isOn = mutingpostproc;
        music.GetComponent<AudioSource>().mute = mutingmusic;
        sfx.GetComponent<AudioSource>().mute = mutingsfx;
        bool intToBool(int val)
        {
            if (val != 0)
                return true;
            else
                return false;
        }
    }
    void Update()
    {
        if (togglesfx.isOn == true)
        {
            sfx.GetComponent<AudioSource>().mute = true;
            mutingsfx = true;
            PlayerPrefs.SetInt("MuteSFX", 1);
            PlayerPrefs.Save();
        }
        else
        {
            sfx.GetComponent<AudioSource>().mute = false;
            mutingsfx = false;
            PlayerPrefs.SetInt("MuteSFX", 0);
            PlayerPrefs.Save();
        }
        if (togglemusic.isOn == true)
        {
            music.GetComponent<AudioSource>().mute = true;
            mutingmusic = true;
            PlayerPrefs.SetInt("MuteMusic", 1);
            PlayerPrefs.Save();
        }
        else
        {
            music.GetComponent<AudioSource>().mute = false;
            mutingmusic = false;
            PlayerPrefs.SetInt("MuteMusic", 0);
            PlayerPrefs.Save();
        }
        music.GetComponent<AudioSource>().mute = mutingmusic;
        sfx.GetComponent<AudioSource>().mute = mutingsfx;
        if (togglepostproc.isOn == false)
        {
            Volume.weight = 0;
            mutingpostproc = false;
            PlayerPrefs.SetInt("MutePostProc", 0);
            PlayerPrefs.Save();
        }
        else
        {
            Volume.weight = 1;
            mutingpostproc = true;
            PlayerPrefs.SetInt("MutePostProc", 1);
            PlayerPrefs.Save();
        }
    }
}
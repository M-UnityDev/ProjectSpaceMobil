using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class OptionsInterface : MonoBehaviour
{
    [SerializeField] private GameObject music;
    [SerializeField] private GameObject sfx;
    [SerializeField] private PostProcessVolume Volume;
    public int postproc;
    public int mutingmusic;
    public int mutingsfx;
    void Start()
    {Application.targetFrameRate = 60; }
    void Update()
    {
        mutingmusic = PlayerPrefs.GetInt("MuteMusic", 0);
        postproc = PlayerPrefs.GetInt("MutePostProc", 1);
        mutingsfx = PlayerPrefs.GetInt("MuteSFX", 0);
        if (mutingmusic == 1)
        {
            music.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            music.GetComponent<AudioSource>().mute = false;
        }
        if (mutingsfx == 1)
        {
            sfx.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            sfx.GetComponent<AudioSource>().mute = false;
        }
        Volume.weight = postproc;
    }
}

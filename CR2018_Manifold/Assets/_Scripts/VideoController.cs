using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer VidPlayer;
    public Material SkyboxMaterial;
    public bool PlayOnStart = false;
    public bool PlayOnEnable = false;
    public bool PlayAudio = false;
    public AudioSource AudSource;
    public UnityEvent OnStartVideo;
    public UnityEvent OnEndVideo;

    public void Start()
    {
        if (PlayOnStart)
        {
            StartVideo();
        }
    }

    public void OnEnable()
    {
        if (PlayOnEnable)
        {
            StartVideo();
        }
    }

    public void StartVideo()
    {
        RenderSettings.skybox = SkyboxMaterial;

        VidPlayer.Play();
        if (PlayAudio)
        {
            AudSource.Play();
        }
        //VidPlayer.
        OnStartVideo.Invoke();
    }

    public void EndVideo()
    {
        VidPlayer.Stop();
        OnEndVideo.Invoke();
    }

}

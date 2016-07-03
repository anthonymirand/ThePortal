using UnityEngine;
using System.Collections;

public class PlayMovieOnSpace : MonoBehaviour
{

    public MovieTexture video1;
    public AudioClip audio1;
    public MovieTexture video2;
    public AudioClip audio2;
    private Renderer r;
    private AudioSource aud;
    public bool isSwitch = false;
    public bool isDead = false;

    private bool wait = false;

    IEnumerator pause(float time)
    {
        yield return new WaitForSeconds(time);
        wait = true;
    }

    void Start()
    {
        StartCoroutine(pause(12.0f));
    }

    void Update()
    {
        if (wait)
        {
            StartCoroutine(pause(12.0f));
            r = GetComponent<Renderer>();
            r.material.mainTexture = video1 as MovieTexture;
            video1.Play();
            aud = GetComponent<AudioSource>();
            aud.clip = audio1;
            aud.Play();
            wait = false;
        }

        if (isSwitch)
        {
            switchVideo();
        }

        if (isDead)
        {
            killVideo();
        }
    }

    void switchVideo()
    {

        video1.Stop();
        aud.Stop();
        r.material.mainTexture = video2 as MovieTexture;
        video2.Play();
        aud.clip = audio2;
        aud.Play();

        isSwitch = false;

    }

    void killVideo()
    {
        video1.Stop();
        aud.Stop();
        r.enabled = false;
    }
}

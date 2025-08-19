using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public bool stop,pause;
    public AudioClip[] AC;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = AC[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            audioSource.Stop();
        }
        if (pause)
        {
            audioSource.Pause();
        }
        if (!pause)
        {
            audioSource.UnPause();
        }
    }
}

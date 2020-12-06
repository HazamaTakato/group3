using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioPlay(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
    public void AudioStop()
    {
        audioSource.Stop();
    }
}

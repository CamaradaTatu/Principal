using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource;
    public bool notDestroy;
    private void Awake()
    {
        if(notDestroy)
        {
            DontDestroyOnLoad(this);
        }
    }
    public void Play(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}

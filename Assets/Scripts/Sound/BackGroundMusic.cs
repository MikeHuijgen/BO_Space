using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BackGroundMusic : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float volume; 
    [NonSerialized] public AudioSource audioSource;
    public bool canPlay;
    void Start()
    {
        canPlay = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volume;
        PlayMusic();
    }

    void PlayMusic()
    {
        if (canPlay)
        {
            audioSource.Play();
            canPlay = false;
        }

        if (audioSource.isPlaying == false)
        {
            canPlay = true;
        }
    }
}

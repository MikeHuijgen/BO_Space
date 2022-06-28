using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEventSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] BackGroundMusic backGroundMusic;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlaySound();
    }

    void PlaySound()
    {
        audioSource.Play();

        if (audioSource.isPlaying)
        {
            backGroundMusic.enabled = false;
        }
        else if (!audioSource.isPlaying)
        {
            backGroundMusic.enabled = true;
        }
        
    }
}

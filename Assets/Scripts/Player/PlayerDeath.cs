using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] public bool playerDied = false;
    [SerializeField] private MouseLook mouselook;
    [SerializeField] private Canvas deathScreen;
    [SerializeField] private Canvas playerUI;
    [SerializeField] private CamShake camShake;
    private AudioSource audioSource;
    [SerializeField] AudioClip deathSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        deathScreen.enabled = false;
    }

    void PlayerDies()
    {
        audioSource.clip = deathSound;
        audioSource.loop = false;
        audioSource.volume = 1;
        audioSource.Play();
        StartCoroutine(camShake.Shake());
        playerDied = true;
        mouselook.curserLock = false;
        playerUI.enabled = false;
        deathScreen.enabled = true;
    }

    public void CheckForPlayerDead(bool value)
    {
        if (value)
        {
            PlayerDies();
        }
    }
}

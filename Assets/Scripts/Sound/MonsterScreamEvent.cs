using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScreamEvent : MonoBehaviour
{
    AudioSource audioSource;
    private bool canPlaySound;
    private Collider triggerCollider;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        triggerCollider = GetComponent<Collider>(); 
        canPlaySound = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggerCollider.enabled = false;
            audioSource.Play();
            canPlaySound = false;
        }
    }

    private void Update()
    {
        DestroyObject();
    }

    private void DestroyObject()
    {
        if (canPlaySound == false && !audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}

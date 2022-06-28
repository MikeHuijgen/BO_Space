using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject door;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Stop();
            audioSource.Play();
            door.GetComponent<DoorScript>().isClosing = false;
            door.GetComponent<DoorScript>().isOpening = true;
            Debug.Log("In");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Stop();
            audioSource.Play();
            door.GetComponent<DoorScript>().isOpening = false;
            door.GetComponent<DoorScript>().isClosing = true;
            Debug.Log("Out");
        }
    }
}

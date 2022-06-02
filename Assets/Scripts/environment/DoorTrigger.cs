using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.GetComponent<DoorScript>().isClosing = false;
            door.GetComponent<DoorScript>().isOpening = true;
            Debug.Log("In");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.GetComponent<DoorScript>().isOpening = false;
            door.GetComponent<DoorScript>().isClosing = true;
            Debug.Log("Out");
        }
    }
}

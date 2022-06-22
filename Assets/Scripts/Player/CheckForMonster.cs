using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForMonster : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject flashLight;

    private FlashLight flashLightScript;
    private bool canTurnOn;

    private void Start()
    {
        flashLightScript = flashLight.GetComponent<FlashLight>();
    }


    private void OnTriggerStay(Collider other)
    {
        // It checks if the monster is in your trigger
        if (other.gameObject.CompareTag("monster"))
        {
            flashLightScript.StartCoroutine(flashLightScript.LightFlicker());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the monster not in the trigger anymore canTurnOn turns true
        if (other.gameObject.tag == "monster")
        {
            flashLightScript.canFlicker = true;
        }
    }
}

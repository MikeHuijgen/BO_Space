using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [Header("Flashlight Settings")]
    [SerializeField] private float intensityLight;
    

    [Header("Flicker Settings")]
    [SerializeField] private int intensityRandom1;
    [SerializeField] private int intensityRandom2;
    [SerializeField] private float delayRandom1;
    [SerializeField] private float delayRandom2;
   
    [Header("References")]
    [SerializeField] private Light headLight;
    [SerializeField] private GameObject monster;
    [SerializeField] private Transform flashLight;
    [SerializeField] private Transform monsterSpawn;

    [Header("Sound")]
    [SerializeField] private AudioClip turnOnSound;

    private float delay;
    public bool canTurnOn = true;
    private Vector3 spawnPointMonster;
    private float zPosMonster;
    private AudioSource audioSource;

    public bool lightTurnedUn;

    private void Start()
    {
        headLight.intensity = intensityLight;
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        TurnOn_OffLight();
        LightTimer();
    }

    void TurnOn_OffLight()
    {
        // It turn the flashlight on and off and play a sound effect
        if (Input.GetKeyUp(KeyCode.G))
        {
            audioSource.PlayOneShot(turnOnSound);
            headLight.enabled = !headLight.enabled;
        }
    }

    void LightTimer()
    {
        // Set the bool true or false if the flashlight is on or off
        if (headLight.enabled == true)
        {
            lightTurnedUn = true;
        }
        else
        {
            lightTurnedUn = false;
        }
    }


    public IEnumerator LightFlicker()
    {
        canTurnOn = false;

        // Gives the flashlight a random intensity between the two numbers
        headLight.intensity = Random.Range(intensityRandom1,intensityRandom2);

        // Gives the flashlight a random delay between flickering
        delay = Random.Range(delayRandom1, delayRandom2);

        yield return new WaitForSeconds(delay);
        headLight.intensity = intensityLight;
        canTurnOn = true;
    }
}

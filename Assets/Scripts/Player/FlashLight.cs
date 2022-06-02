using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [Header("Flashlight Settings")]
    [SerializeField] private float intensityLight;
    [SerializeField] private float lightTime;
    [SerializeField] private float flickeringTime;
    [SerializeField] private float maxLightTime;
    

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
    private bool canTurnOn = true;
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
        SpawnMonster();
    }

    void TurnOn_OffLight()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            audioSource.PlayOneShot(turnOnSound);
            headLight.enabled = !headLight.enabled;
        }
    }

    void LightTimer()
    {
        if (headLight.enabled == true)
        {
            lightTurnedUn = true;
            lightTime += Time.deltaTime;
        }
        else if (!headLight.enabled)
        {
            lightTurnedUn = false;
            lightTime -= Time.deltaTime;
        }
        
        if (lightTime < 0)
        {
            lightTime = 0;
        }

        if (lightTime >= flickeringTime)
        {
            if (canTurnOn)
            {
                StartCoroutine(LightFlicker());
            }
            
        }

    }



    IEnumerator LightFlicker()
    {
        canTurnOn = false;
        headLight.intensity = Random.Range(intensityRandom1,intensityRandom2);
        delay = Random.Range(delayRandom1, delayRandom2);
        yield return new WaitForSeconds(delay);
        headLight.intensity = intensityLight;
        canTurnOn = true;
    }

    void SpawnMonster()
    { 
        if (lightTime >= maxLightTime)
        {
            lightTime = 0;
            headLight.enabled = false;
            Instantiate(monster, monsterSpawn.position, Quaternion.identity);
        }
    }
}

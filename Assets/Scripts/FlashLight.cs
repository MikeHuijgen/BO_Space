using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [Header("Flashlight Settings")]
    [SerializeField] float intensityLight;
    [SerializeField] float lightTime;
    [SerializeField] float firstFlicker;
    [SerializeField] float maxLightTime;

    [Header("Flicker Settings")]
    [SerializeField] int intensityRandom1;
    [SerializeField] int intensityRandom2;
    [SerializeField] float delayRandom1;
    [SerializeField] float delayRandom2;
   
    [Header("References")]
    [SerializeField] Light headLight;
    [SerializeField] GameObject monster;
    [SerializeField] Transform flashLight;

    float delay;
    bool canTurnOn = true;
    Vector3 spawnPointMonster;
    float zPosMonster;

    private void Start()
    {
        headLight.intensity = intensityLight;
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
            headLight.enabled = !headLight.enabled;
        }
    }

    void LightTimer()
    {
        if (headLight.enabled == true)
        {
            lightTime += Time.deltaTime;
        }
        else if (!headLight.enabled)
        {
            lightTime -= Time.deltaTime;

        }
        
        if (lightTime < 0)
        {
            lightTime = 0;
        }

        if (lightTime >= firstFlicker)
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
        zPosMonster = flashLight.position.z - 2f;
        spawnPointMonster = new Vector3(0, 1, zPosMonster);
        if (lightTime >= maxLightTime)
        {
            lightTime = 0;
            headLight.enabled = false;
            Instantiate(monster, spawnPointMonster, Quaternion.identity);
        }
    }

}

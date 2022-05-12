using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [Header("Flashlight Settings")]
    [SerializeField] float intensityLight;
    [SerializeField] float turnedUnLight;
    [SerializeField] int turnUnFlickerLight;
    [SerializeField] bool IsFlickering;

    [Header("References")]
    [SerializeField] Light lightSource;

    float test = 0;

    private void Start()
    {
        lightSource.intensity = intensityLight;
    }

    void Update()
    {
        TurnOn_OffLight();
        LightTimer();
    }


    void TurnOn_OffLight()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            lightSource.enabled = !lightSource.enabled;
        }
    }

    void LightTimer()
    {
        if (lightSource.enabled == true)
        {
            turnedUnLight += Time.deltaTime;
        }
        else if (!lightSource.enabled && turnedUnLight > 0)
        {
            turnedUnLight -= Time.deltaTime;
        }
        
        if (turnedUnLight < 0)
        {
            turnedUnLight = 0;
        }
        else if(turnedUnLight > 6)
        {
            StartCoroutine(LightFlickerEffect());
        }
    }

    IEnumerator LightFlickerEffect()
    {
        IsFlickering = true;
        lightSource.enabled = false;
        yield return new WaitForSeconds(1f);
        lightSource.enabled = true;
        IsFlickering = false;
    }

}

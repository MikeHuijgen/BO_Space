using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sanity : MonoBehaviour
{
    [SerializeField] private GameObject flashLight;
    [SerializeField] private float sanityTimer;
    [SerializeField] private float maxSanityTime;

    private FlashLight flashLightScript;
    private bool youDied;
    // Start is called before the first frame update
    void Start()
    {
        flashLightScript = flashLight.GetComponent<FlashLight>();
    }

    // Update is called once per frame
    void Update()
    {
        SanityTimer();
    }

    void SanityTimer()
    {
        // it makes your sanityTimer go up if the flashlight is on and it goes down if the flashlight is off
        if (flashLightScript.lightTurnedUn == true && sanityTimer > 0 && !youDied)
        {
            sanityTimer -= Time.deltaTime;
        }
        else if (flashLightScript.lightTurnedUn == false && !youDied)
        {
            sanityTimer += Time.deltaTime;
        }

        // it reset your sanityTimer
        if (sanityTimer < 0)
        {
            sanityTimer = 0;
        }
        else if (sanityTimer > maxSanityTime)
        {
            YouDied();
        }
    }

    private void YouDied()
    {
        youDied = true;
        sanityTimer = 0;
        Debug.Log("You Died");
    }
}

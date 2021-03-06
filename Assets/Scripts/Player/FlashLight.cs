using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private GameObject tipPanel;

    [Header("Sound")]
    [SerializeField] private AudioClip turnOnSound;

    private float delay;
    public bool canFlicker = true;
    private AudioSource audioSource;
    private Ray ray;
    private RaycastHit hitInfo;

    public bool lightTurnedUn;

    private void Start()
    {
        tipPanel.SetActive(true);
        headLight.intensity = intensityLight;
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        TurnOn_OffLight();
        TurnOnLightBool();
    }

    void TurnOn_OffLight()
    {
        // It turn the flashlight on and off and play a sound effect
        if (Input.GetKeyUp(KeyCode.F))
        {
            tipPanel.SetActive(false);
            audioSource.PlayOneShot(turnOnSound);
            headLight.enabled = !headLight.enabled;
        }
    }

    void TurnOnLightBool()
    {
        // Set the bool true or false if the flashlight is on or off
        if (headLight.enabled == true)
        {
            lightTurnedUn = true;
            LightHitSlime();
        }
        else
        {
            lightTurnedUn = false;
        }
    }


    public IEnumerator LightFlicker()
    {
        // Gives the flashlight a random intensity between the two numbers
        headLight.intensity = Random.Range(intensityRandom1,intensityRandom2);

        // Gives the flashlight a random delay between flickering
        delay = Random.Range(delayRandom1, delayRandom2);

        yield return new WaitForSeconds(delay);
        headLight.intensity = intensityLight;
    }

    void LightHitSlime()
    { 
        ray.origin = headLight.transform.position;
        ray.direction = headLight.transform.forward;

        if (Physics.Raycast(ray, out hitInfo, 3))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1f);
            if (hitInfo.collider.tag == "Slime")
            {
                DissolveSlime dissolveSlimeScript = hitInfo.transform.GetComponent<DissolveSlime>();
                dissolveSlimeScript.DissolveHit(true);
            }
            else
            {
                Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1f);
            }

        }

    }
}

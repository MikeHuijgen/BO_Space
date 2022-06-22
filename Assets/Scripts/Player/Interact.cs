using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cameraT;
    [SerializeField] private TMP_Text interactText;

    [Header("LayerMasks")]
    [SerializeField] private LayerMask Ibutton;
    private Ray ray;
    private RaycastHit hitInfo;

    private GameObject door;
    private DoorScript doorScript;
    
    [SerializeField] bool showText = true;

    private void Start()
    {
        door = GameObject.FindWithTag("Door");
        doorScript = door.GetComponent<DoorScript>();
    }

    private void Update()
    {
        CheckRayCast();
    }

    void CheckRayCast()
    {
        ray.origin = cameraT.position;
        ray.direction = cameraT.forward;

        if (Physics.Raycast(ray, out hitInfo, 10f, Ibutton))
        {
            ShowInteractText();

            interactText.text = $"Press E to press the button";

            Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1f);

            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractWithButton();
            }
        }
        else
        {
            interactText.enabled = false;
        }
    }

    void InteractWithButton()
    {
        Terminal terminal = hitInfo.transform.GetComponent<Terminal>();
        terminal.Active(true);
    }

    public void CheckSeeInteractText(bool value)
    {
        if (value)
        {
            showText = true;
        }

        if (!value)
        {
           showText = false;
        }
    }

    void ShowInteractText()
    {
        if (showText)
        {
            interactText.enabled = true;
        }
        else
        {
            interactText.enabled = false;
        }
    }
}

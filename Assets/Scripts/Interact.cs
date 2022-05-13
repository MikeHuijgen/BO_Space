using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform cameraT;
    [SerializeField] TMP_Text interactText;

    [Header("LayerMasks")]
    [SerializeField] LayerMask Ibutton;
    [SerializeField] LayerMask Iobject;
    Ray ray;
    RaycastHit hitInfo;

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
            interactText.enabled = true;
            interactText.text = $"Press E to press the button";
            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractWithButton();
            }
        }
        else if (Physics.Raycast(ray, out hitInfo, 10f, Iobject))
        {
            interactText.enabled = true;
            interactText.text = $"Press E to pick up the object";
            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractWithObject();
            }
        }
        else
        {
            interactText.enabled = false;
        }
    }

    void InteractWithButton()
    {
        Debug.Log("You pressed the button");
    }

    void InteractWithObject()
    {
        Debug.Log("You interact with the object");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform cameraT;
    [SerializeField] TMP_Text interactText;
    [SerializeField] Transform objectPickUp;

    [Header("LayerMasks")]
    [SerializeField] LayerMask Ibutton;
    [SerializeField] LayerMask Iobject;
    Ray ray;
    RaycastHit hitInfo;

    bool pickedUp;
    InteractObject interactObject;
    [SerializeField] bool showText = true;

    private void Update()
    {
        CheckRayCast();
        DropObject();
    }

    void CheckRayCast()
    {
        ray.origin = cameraT.position;
        ray.direction = cameraT.forward;

        if (Physics.Raycast(ray, out hitInfo, 10f, Ibutton))
        {
            ShowInteractText();

            interactText.text = $"Press E to press the button";

            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractWithButton();
            }
        }
        else if (Physics.Raycast(ray, out hitInfo, 10f, Iobject))
        {
            ShowInteractText();

            interactText.text = $"Press E to pick up the object";

            objectPickUp = hitInfo.transform.parent.transform;

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

        pickedUp = true;

        interactObject = objectPickUp.transform.GetComponent<InteractObject>();
        interactObject.IsPickedUp(pickedUp);
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

    void DropObject()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            interactObject.PlaceObjectBack(true);
        }
    }
}

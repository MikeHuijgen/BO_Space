using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cameraT;
    [SerializeField] private TMP_Text interactText;
    [SerializeField] private Transform objectPickUp;

    [Header("LayerMasks")]
    [SerializeField] private LayerMask Ibutton;
    [SerializeField] private LayerMask Iobject;
    private Ray ray;
    private RaycastHit hitInfo;

    private bool pickedUp;
    private InteractObject interactObject;
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

            Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1f);

            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractWithButton();
            }
        }
        else if (Physics.Raycast(ray, out hitInfo, 10f, Iobject))
        {
            ShowInteractText();

            interactText.text = $"Press E to pick up the object";

            Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1f);

            if (Input.GetKeyDown(KeyCode.E))
            {
                objectPickUp = hitInfo.transform.parent.transform;
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
        Terminal terminal = hitInfo.transform.GetComponent<Terminal>();
        terminal.Active(true);
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

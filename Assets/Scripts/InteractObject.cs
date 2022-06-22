using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractObject : MonoBehaviour
{
    [Header("InteractObject Settings")]
    [SerializeField] float rotateSpeed;

    [Header("References")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerCam;
    [SerializeField] GameObject inspectObjectTransform;
    [SerializeField] TMP_Text interactText;

    [SerializeField] bool pickedUp = false;
    [SerializeField] bool onRightSpot = false;
    [SerializeField] bool putBackObject = false;

    [SerializeField] Vector3 oldPos;
    [SerializeField] Quaternion oldRot;

    float mouseX;
    float mouseY;

    private void Start()
    {
        oldPos = transform.position;
        oldRot = transform.rotation;
    }

    private void Update()
    {
        PlaceBeforeCamera();
        RotateObject();
    }

    public void IsPickedUp(bool value)
    {
        pickedUp = value;
    }

    void PlaceBeforeCamera()
    {
        if (pickedUp)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            playerCam.GetComponent<MouseLook>().enabled = false;
            player.GetComponent<Interact>().CheckSeeInteractText(false);
            interactText.enabled = false;

            transform.parent = inspectObjectTransform.transform;
            transform.position = inspectObjectTransform.transform.position;
            onRightSpot = true;
        }
    }

    void RotateObject()
    {
        if (onRightSpot)
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");

            transform.Rotate(0,mouseX * rotateSpeed * Time.deltaTime,mouseY * rotateSpeed * Time.deltaTime);
            
        }
    }

    public void PlaceObjectBack(bool value)
    {   
        putBackObject = value;

        if (putBackObject == true)
        {
            inspectObjectTransform.transform.DetachChildren();
            transform.position = oldPos;
            transform.rotation = oldRot;
            playerCam.GetComponent<MouseLook>().enabled = true;
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<Interact>().CheckSeeInteractText(true);
            putBackObject = false;
            onRightSpot = false;
            pickedUp = false;
        }
    }
}

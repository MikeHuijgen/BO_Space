using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractObject : MonoBehaviour
{
    [Header("InteractObject Settings")]
    [SerializeField] private float rotateSpeed;

    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject inspectObjectTransform;
    [SerializeField] private TMP_Text interactText;

    [SerializeField] private bool pickedUp = false;
    [SerializeField] private bool onRightSpot = false;
    [SerializeField] private bool putBackObject = false;

    [SerializeField] private Vector3 oldPos;
    [SerializeField] private Quaternion oldRot;

    private float mouseX;
    private float mouseY;

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

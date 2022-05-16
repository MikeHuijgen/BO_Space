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
    [SerializeField] GameObject inspectObjectTransform;
    [SerializeField] TMP_Text interactText;

    [SerializeField] bool pickedUp = false;
    [SerializeField] bool onRightSpot = false;
    [SerializeField] bool putBackObject = false;

    [SerializeField] Vector3 oldPos;

    float mouseX;
    float mouseY;

    private void Start()
    {
        oldPos = transform.position;
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
            player.GetComponent<walk>().enabled = false;
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
        if (value)
        {
            putBackObject = true;
        }    

        if (putBackObject)
        {
            inspectObjectTransform.transform.DetachChildren();
            transform.position = oldPos;
            player.GetComponent<walk>().enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    public bool curserLock;

    private void Start()
    {
        curserLock = true;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        //if (Input.GetKey("CTRL"))
       // {
           // transform.Translate.yposition(0);
       // }

        MouseCursorHide();
    }

    void MouseCursorHide()
    {
        if (curserLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
           Cursor.lockState = CursorLockMode.None;
           Cursor.visible = true;
        }
    }
}

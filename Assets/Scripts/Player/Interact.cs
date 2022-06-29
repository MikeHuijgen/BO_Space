using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cameraT;
    [SerializeField] private GameObject interactPanel;

    [Header("LayerMasks")]
    [SerializeField] private LayerMask Ibutton;
    private Ray ray;
    private RaycastHit hitInfo;
    
    [SerializeField] bool showText = true;

    private void Update()
    {
        CheckRayCast();
    }

    void CheckRayCast()
    {
        ray.origin = cameraT.position;
        ray.direction = cameraT.forward;

        if (Physics.Raycast(ray, out hitInfo, 2, Ibutton))
        {
            interactPanel.SetActive(true);

            Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1f);

            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractWithButton();
            }
        }
        else
        {
            interactPanel.SetActive(false);
        }
    }

    void InteractWithButton()
    {
        Terminal terminal = hitInfo.transform.GetComponent<Terminal>();
        terminal.Active(true);
    }
}

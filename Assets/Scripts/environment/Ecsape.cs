using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ecsape : MonoBehaviour
{
    [SerializeField] private Canvas playerUI;
    [SerializeField] private Canvas escapeScreen;
    [SerializeField] private MouseLook mouseLook;
    public bool hasEscaped = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hasEscaped = true;  
            Time.timeScale = 0;
            mouseLook.curserLock = false;
            escapeScreen.enabled = true;
            playerUI.enabled = false;
        }
    }
}

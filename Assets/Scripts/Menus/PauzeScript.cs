using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauzeScript : MonoBehaviour
{
    [SerializeField] Canvas pauzeScreen;
    [SerializeField] private Canvas playerUI;
    [SerializeField] private MouseLook mouseLook;
    [SerializeField] private PlayerDeath playerDeath;

    private void Start()
    {
        pauzeScreen.enabled = false;
    }

    private void Update()
    {
        ActivePauzeScreen();
    }

    void ActivePauzeScreen()
    {
        if (playerDeath.playerDied == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauzeScreen.enabled = !pauzeScreen.enabled;
            }

            if (pauzeScreen.enabled)
            {
                playerUI.enabled = false;
                Time.timeScale = 0;
                mouseLook.curserLock = false;
            }
            else
            {
                playerUI.enabled = true;
                Time.timeScale = 1;
            }
        }
    }

    public void OnPauze(bool clicked)
    {
        if (clicked)
        {
            Time.timeScale = 1;
            pauzeScreen.enabled = false;
            mouseLook.curserLock = true;
            clicked = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] public bool playerDied = false;
    [SerializeField] private MouseLook mouselook;
    [SerializeField] private Canvas deathScreen;
    [SerializeField] private Canvas playerUI;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Camera menuCamera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerDies();
        }
    }
    void PlayerDies()
    {
        mouselook.curserLock = false;
        Time.timeScale = 0;
        playerUI.enabled = false;
        menuCamera.enabled = true;
        playerCamera.enabled = false;
        deathScreen.enabled = true;
    }

    public void CheckForPlayerDead(bool value)
    {
        if (value)
        {
            PlayerDies();
        }
    }
}

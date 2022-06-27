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

    private void Start()
    {
        deathScreen.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerDies();
        }
    }
    void PlayerDies()
    {
        playerDied = true;
        Time.timeScale = 0;
        mouselook.curserLock = false;
        playerUI.enabled = false;
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

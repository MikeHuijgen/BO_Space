using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        PlayerDies();
    }

    void PlayerDies()
    {
        // need to change if the monster hits you then you die
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerDied = true;
        }

        if (playerDied)
        {
            mouselook.curserLock = false;
            Time.timeScale = 0;
            playerUI.enabled = false;
            menuCamera.enabled = true;
            playerCamera.enabled = false;
            deathScreen.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("monster"))
        {
            playerDied = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] public bool playerDied = false;
    [SerializeField] private Canvas deathScreen;

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

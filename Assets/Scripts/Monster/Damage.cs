using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Damage : MonoBehaviour
{
    private float targetDis = Mathf.Infinity;
    [SerializeField] private NavMeshAgent monsterAI;
    [SerializeField] private GameObject player;
    private PlayerDeath playerDeath;

    private void Start()
    {
        playerDeath = player.GetComponent<PlayerDeath>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            KillPlayer();
            Debug.Log("Hit");
        }
    }


    void KillPlayer()
    {
        playerDeath.CheckForPlayerDead(true);
    }
}

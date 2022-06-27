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

    // Update is called once per frame
    void Update()
    {
        targetDis = Vector3.Distance(player.transform.position, transform.position);
        KillPlayer();
    }

    void KillPlayer()
    {
        if (targetDis <= monsterAI.stoppingDistance)
        {
            playerDeath.CheckForPlayerDead(true);
        }
    }
}

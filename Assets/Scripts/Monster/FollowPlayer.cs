using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private GameObject flashLight;

    private bool lightIsOn;
    private Vector3 startPos;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPos = transform.position;
    }

    private void Update()
    {
        FollowPlayerPosition();
    }

    void FollowPlayerPosition()
    {
        // if the player turn on the flashlight the monster will go to the player position

        lightIsOn = flashLight.GetComponent<FlashLight>().lightTurnedUn;

        if (lightIsOn == true)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            //Need to change with the waypoint path
            agent.SetDestination(startPos);
        }
    }
}

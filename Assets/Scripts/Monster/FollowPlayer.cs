using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private GameObject flashLight;
    
    
    public patrolling patrolling;
    public DoorScript doorScript;
    
    

    private bool lightIsOn;
    

    public NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
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
        if (doorScript.monsterCanOpen == true)
        {
            patrolling.destPoint = (int)Mathf.Floor(Random.Range(0, 7)); }
        else
        {
            //Need to change with the waypoint path
            patrolling.destPoint = (int)Mathf.Floor(Random.Range(0, 5));
        }
    }
}

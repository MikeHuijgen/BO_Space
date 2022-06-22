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
    //public DoorScript doorScript;

    

    private bool lightIsOn;
    private bool chasing; 

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
            chasing = true;
            agent.SetDestination(player.position);
        }
        else if(lightIsOn == false && chasing == true)
        {
            StartCoroutine(Freeze());
        }
    }

    public IEnumerator Freeze()
    {
        chasing = false;
        agent.isStopped = true;
        Debug.Log("Im waiting 1 second");
        yield return new WaitForSeconds(1);
        Debug.Log("kies een nieuwe patrol destination");
        agent.isStopped = false;
        patrolling.GotoNextPoint();
    }
}

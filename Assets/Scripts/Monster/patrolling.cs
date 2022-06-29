using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrolling : MonoBehaviour
{
    public Transform[] points;
    public int destPoint = 0;
    public NavMeshAgent agent;
    private GameObject door;
    public DoorScript doorScript;
    public LightEvent lightpoint;
    public Transform lightEventTransform;
    Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        //doorScript.GetComponent<DoorScript>();
        //doorScript = FindObjectOfType<DoorScript>();
        animator = GetComponent<Animator>();



    }

    public void GotoNextPoint()
    { 
       
        
        if (points.Length == 0)
            return;
        else
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isRunning", false);
            destPoint = (int)Mathf.Floor(Random.Range(0, 6));
        }

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.5f)
            GotoNextPoint();
        monsterEvent();
        
    }

    void monsterEvent()
    {
        if (lightpoint.monsterBool == true)
        {
            agent.speed = 6f;
            agent.SetDestination(lightEventTransform.position);
        }
        else
        {
            agent.speed = 3.5f;
        }
     
    if (agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
            
    
        
    }


}

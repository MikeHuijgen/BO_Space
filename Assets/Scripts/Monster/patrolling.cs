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

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        doorScript.GetComponent<DoorScript>();
        //doorScript = FindObjectOfType<DoorScript>();



        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        if (doorScript.monsterCanOpen == true)
        {
            destPoint = (int)Mathf.Floor(Random.Range(0, 7));
        }
        else
        {
            destPoint = (int)Mathf.Floor(Random.Range(0, 5));
        }

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    

    }


}

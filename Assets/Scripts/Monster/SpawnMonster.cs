using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject door;
    DoorScript doorScript;
    private void Start()
    {
        doorScript = door.GetComponent<DoorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnIn();
    }

    private void SpawnIn()
    {
        if(doorScript.doorActive)
        {
            monster.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [Header("Door Settings")]
    [SerializeField] private int closeDoorTime;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 oldDoorPos;
    [SerializeField] private Vector3 maxHeightPos;
    [SerializeField] private int openHeight;
    
    [Header("Bool Settings")]
    [SerializeField] public bool isOpening = false;
    [SerializeField] private bool activeTerminal1 = false;
    [SerializeField] private bool activeTerminal2 = false;
    [SerializeField] public bool isClosing;
    [SerializeField] public bool monsterCanOpen = false;

    [Header("References")]
    [SerializeField] private Transform beginPos;
    [SerializeField] private Collider doorTrigger;
    [SerializeField] private GameObject terminal1;
    [SerializeField] private GameObject terminal2;
    [SerializeField] private Transform maxHeightTransform;

    private Terminal terminalScript1;
    private Terminal terminalScript2;

    private GameObject door;
    private float doorY;


    private void Start()
    {
        door = GameObject.FindWithTag("Door");
        oldDoorPos = beginPos.transform.position;
        terminalScript1 = terminal1.transform.GetComponent<Terminal>();
        terminalScript2 = terminal2.transform.GetComponent<Terminal>();
        doorTrigger.enabled = false;

        maxHeightPos = maxHeightTransform.position;
    }

    private void Update()
    {
        doorY = door.transform.position.y;
        OpenDoor();
        CheckIfCanOpen();
    }

    public void TriggerActive(bool value)
    {
        isOpening = value;
    }

    void CheckIfCanOpen()
    {
        activeTerminal1 = terminalScript1.active;
        activeTerminal2 = terminalScript2.active;

        if (activeTerminal1 == true && activeTerminal2 == true)
        {
            terminalScript1.SetFalse(true);
            terminalScript2.SetFalse(true);
            monsterCanOpen = true;
            doorTrigger.enabled = true;
        }
    }

    void OpenDoor()
    {
        if (isOpening == true)
        {
            door.transform.Translate(0,.1f * speed * Time.deltaTime,0);
        }

        if (doorY > maxHeightTransform.position.y)
        {
            isOpening = false;
            door.transform.Translate(0,0,0);
            StartCoroutine(StopAndCloseDoor());
        }

        if (isClosing == true)
        {
            door.transform.Translate(0, -.1f * speed * Time.deltaTime, 0);
        }

        if (doorY < oldDoorPos.y)
        {
            isClosing = false;
            door.transform.position = oldDoorPos;
        }


    }

    IEnumerator StopAndCloseDoor()
    {
        yield return new WaitForSeconds(closeDoorTime);
        isClosing = true;
    }
}

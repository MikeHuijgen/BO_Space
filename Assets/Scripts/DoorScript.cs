using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [Header("Door Settings")]
    [SerializeField] int closeDoorTime;
    [SerializeField] float speed;
    [SerializeField] Vector3 oldDoorPos;
    
    [Header("Bool Settings")]
    [SerializeField] public bool isOpening = false;
    [SerializeField] bool activeTerminal1 = false;
    [SerializeField] bool activeTerminal2 = false;
    [SerializeField] public bool isClosing;

    [Header("References")]
    [SerializeField] Transform beginPos;
    [SerializeField] Collider doorTrigger;
    [SerializeField] GameObject terminal1;
    [SerializeField] GameObject terminal2;

    Terminal terminalScript1;
    Terminal terminalScript2;

    GameObject door;
    float doorY;


    private void Start()
    {
        door = GameObject.FindWithTag("Door");
        oldDoorPos = beginPos.transform.position;
        terminalScript1 = terminal1.transform.GetComponent<Terminal>();
        terminalScript2 = terminal2.transform.GetComponent<Terminal>();
        doorTrigger.enabled = false;
    }

    private void Update()
    {
        OpenDoor();
        doorY = door.transform.position.y;
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
            doorTrigger.enabled = true;
        }
    }

    void OpenDoor()
    {
        if (isOpening == true)
        {
            door.transform.Translate(0,.1f * speed * Time.deltaTime,0);
        }

        if (doorY > 3)
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

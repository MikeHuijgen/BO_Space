using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [Header("Door Settings")]
    [SerializeField] private int closeDoorTime;
    [SerializeField] private float speed;
    public Vector3 oldDoorPos;
    private Vector3 maxHeightPos;
    
    [Header("Bool Settings")]
    [SerializeField] public bool isOpening = false;
    [SerializeField] private bool activeTerminal1 = false;
    [SerializeField] private bool activeTerminal2 = false;
    public bool isClosing;
    public bool doorActive = false;

    [Header("References")]
    [SerializeField] private Transform beginPos;
    [SerializeField] private GameObject door;
    [SerializeField] private Collider doorTrigger;
    [SerializeField] private GameObject terminal1;
    [SerializeField] private GameObject terminal2;
    [SerializeField] private Transform maxHeightTransform;

    private Terminal terminalScript1;
    private Terminal terminalScript2;

    public float doorY;


    private void Start()
    {
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
            doorActive = true;
            StartCoroutine(SetTerminalsFalse());
            doorTrigger.enabled = true;
        }
    }

    void OpenDoor()
    {
        if (isOpening == true)
        {
            door.transform.Translate(0,0, .1f * speed * Time.deltaTime);
        }

        if (doorY > maxHeightTransform.position.y)
        {
            isOpening = false;
            door.transform.Translate(0,0,0);
            StartCoroutine(StopAndCloseDoor());
        }

        if (isClosing == true)
        {
            door.transform.Translate(0, 0, -.1f * speed * Time.deltaTime);
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

    IEnumerator SetTerminalsFalse()
    {
        yield return new WaitForSeconds(1);
        terminalScript1.SetFalse(true);
        terminalScript2.SetFalse(true);
    }
}

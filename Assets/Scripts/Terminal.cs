using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] public bool active;
    [SerializeField] GameObject door;
    DoorScript doorScript;
    public void Active(bool value)
    {
        active = value;
    }

    private void Start()
    {
        doorScript = door.GetComponent<DoorScript>();
    }

    public void SetFalse(bool value)
    {
        if (value == true)
        {
            active = false;
        }
    }
}

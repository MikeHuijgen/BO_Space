using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] public bool active;
    [SerializeField] GameObject door;
    [SerializeField] GameObject terminal;
    public void Active(bool value)
    {
        active = value;
        terminal.layer = 2;
    }

    private void Start()
    {
        terminal = this.gameObject;
    }

    public void SetFalse(bool value)
    {
        if (value == true)
        {
            active = false;
            
        }
    }
}

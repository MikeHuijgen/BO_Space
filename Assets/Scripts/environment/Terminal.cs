using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] public bool active;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject terminal;
    private void Start()
    {
        terminal = this.gameObject;
    }
    public void Active(bool value)
    {
        active = value;
        terminal.layer = 2;
    }


    public void SetFalse(bool value)
    {
        if (value == true)
        {
            active = false;
            
        }
    }
}

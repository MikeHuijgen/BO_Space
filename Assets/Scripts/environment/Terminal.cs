using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] public bool active;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject terminal;
    [SerializeField] private GameObject terminalLight;
    public bool eventBool;
    
    private Material terminalLightMat;
    private void Start()
    {
        terminal = this.gameObject;
        terminalLight.GetComponent<Light>().color = Color.red;
        terminalLightMat = terminalLight.GetComponent<Renderer>().material;
    }

    public void Active(bool value)
    {
        eventBool = value;
        active = value;
        terminalLightMat.SetColor("colormat", Color.green);
        terminalLight.GetComponent<Light>().color = Color.green;
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

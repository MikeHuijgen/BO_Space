using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] public bool active;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject terminal;
    [SerializeField] private GameObject terminalLight1;
    [SerializeField] private GameObject terminalLight2;
    public bool eventBool;
    
    private Material terminalLightMat1; 
    private Material terminalLightMat2;
    private void Start()
    {
        terminal = this.gameObject;
        terminalLight1.GetComponent<Light>().color = Color.red;
        terminalLight2.GetComponent<Light>().color= Color.red;
        terminalLightMat1 = terminalLight1.GetComponent<Renderer>().material;
        terminalLightMat2 = terminalLight2.GetComponent<Renderer>().material;
    }

    public void Active(bool value)
    {
        eventBool = value;
        active = value;
        terminalLightMat1.SetColor("colormat", Color.green);
        terminalLightMat2.SetColor("colormat", Color.green);
        terminalLight1.GetComponent<Light>().color = Color.green;
        terminalLight2.GetComponent<Light>().color = Color.green;
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

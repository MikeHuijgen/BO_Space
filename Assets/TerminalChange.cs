using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalChange : MonoBehaviour
{
    [SerializeField] private Terminal thisTerminal;
    [SerializeField] private Material activeMat;
    [SerializeField] private Material[] terminalScreenMats;

    private void Start()
    {
        terminalScreenMats = gameObject.GetComponent<Renderer>().materials;
        thisTerminal = transform.parent.GetComponent<Terminal>();
    }

    private void Update()
    {
        ChangeScreen();
    }

    void ChangeScreen()
    {
        if (thisTerminal.active)
        {
            terminalScreenMats[1] = activeMat;
            gameObject.GetComponent<Renderer>().materials = terminalScreenMats;
        }
    }
}

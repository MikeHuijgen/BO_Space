using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEvent : MonoBehaviour
{
    [SerializeField] private GameObject terminal;
    [SerializeField] private bool terminalActive;
    [SerializeField] private Light roomLight;
    [SerializeField] public bool roomLightActive;

    private void Update()
    {
        LightEventStart();
    }

    void LightEventStart()
    {
        terminalActive = terminal.GetComponent<Terminal>().active;
        if (terminalActive == true)
        {
            roomLightActive = true;
            roomLight.enabled = true;
        }
    }
}

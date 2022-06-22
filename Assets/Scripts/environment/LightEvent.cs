using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEvent : MonoBehaviour
{
    [SerializeField] private int EventTime;
    [SerializeField] private GameObject terminal;
    [SerializeField] private Light roomLight;
    [SerializeField] public bool roomLightActive;
    [SerializeField] private bool terminalActive;

    private void Update()
    {
        CheckTerminalActive();
    }

    private void CheckTerminalActive()
    {
        terminalActive = terminal.GetComponent<Terminal>().active;

        if (terminalActive == true)
        {
            Debug.Log("i");
            StartCoroutine(LightEventStart());
        }
    }

    IEnumerator LightEventStart()
    {
        roomLight.enabled = true;
        yield return new WaitForSeconds(EventTime);
        roomLight.enabled = false;

    }
}

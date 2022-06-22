using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEvent : MonoBehaviour
{
    [SerializeField] private int EventTime;
    [SerializeField] private GameObject terminal;
    [SerializeField] private Light roomLight;
    [SerializeField] public bool roomLightActive;
    

    private void Update()
    {
        CheckTerminalActive();
    }

    private void CheckTerminalActive()
    {
        roomLightActive = terminal.GetComponent<Terminal>().active;

        if (roomLightActive == true)
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

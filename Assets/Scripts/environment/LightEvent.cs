using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEvent : MonoBehaviour
{
    [SerializeField] private int EventTime;
    [SerializeField] private GameObject terminal;
    [SerializeField] private Light roomLight;
    [SerializeField] private bool roomLightActive;
    [SerializeField] private bool eventCanPlay;
    [SerializeField] public bool monsterBool;

    private void Start()
    {
        eventCanPlay = true;
    }
    private void Update()
    {
        CheckTerminalActive();
    }

    public void CheckTerminalActive()
    {
        roomLightActive = terminal.GetComponent<Terminal>().eventBool;

        if (roomLightActive == true && eventCanPlay == true)
        {
            monsterBool = true;
            Debug.Log("i");
            StartCoroutine(LightEventStart());
        }
    }

    IEnumerator LightEventStart()
    {
        roomLight.enabled = true;
        yield return new WaitForSeconds(EventTime);
        roomLight.enabled = false;
        eventCanPlay = false;
        monsterBool = false;
    }
}

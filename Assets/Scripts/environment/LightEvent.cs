using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEvent : MonoBehaviour
{
    [SerializeField] private int EventTime;
    [SerializeField] private GameObject terminal;
    [SerializeField] private Light roomLight1;
    [SerializeField] private Light roomLight2;
    [SerializeField] private Light roomLight3;
    [SerializeField] private Light roomLight4;
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
        SoundEffect();
        roomLight1.enabled = true;
        roomLight2.enabled = true;
        roomLight3.enabled = true;
        roomLight4.enabled = true;
        yield return new WaitForSeconds(EventTime);
        roomLight1.enabled = false;
        roomLight2.enabled = false;
        roomLight3.enabled = false;
        roomLight4.enabled = false;
        eventCanPlay = false;
        monsterBool = false;
    }

    void SoundEffect()
    {
        //hier komt het geluid
    }
}

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
    [SerializeField] private AudioSource audioSourceBackground;
    [SerializeField] private AudioClip eventClip;
    [SerializeField] private AudioClip backGroundSound;

    [SerializeField] Animator monsterAnimator;

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
            monsterAnimator.SetBool("isRunning", true);
            monsterAnimator.SetBool("isWalking", false);
            PlaySound();
            monsterBool = true;
            StartCoroutine(LightEventStart());
        }
    }

    IEnumerator LightEventStart()
    {
        roomLight1.enabled = true;
        roomLight2.enabled = true;
        roomLight3.enabled = true;
        roomLight4.enabled = true;
        yield return new WaitForSeconds(EventTime);
        monsterAnimator.SetBool("isRunning", false);
        monsterAnimator.SetBool("isWalking", true);
        roomLight1.enabled = false;
        roomLight2.enabled = false;
        roomLight3.enabled = false;
        roomLight4.enabled = false;
        eventCanPlay = false;
        monsterBool = false;
        audioSourceBackground.clip = backGroundSound;
    }

    void PlaySound()
    {
        audioSourceBackground.clip = eventClip;
    }
}

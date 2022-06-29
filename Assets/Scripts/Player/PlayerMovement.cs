using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveX;
    public float moveZ;
    AudioSource audioSource;
    public bool playAudio;

    public float speed = 5f;

    private void Start()
    {
        playAudio = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        FootStepsSound();
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        
        transform.Translate(Vector3.right * moveX * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * moveZ * speed * Time.deltaTime);
    }

    void FootStepsSound()
    {
        if ((moveZ > 0 || moveX > 0 || moveX < 0 || moveZ < 0) && playAudio)
        {
            audioSource.Play();
            playAudio = false;
        }


        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            playAudio = true;
            audioSource.Stop();
        }

    }
}

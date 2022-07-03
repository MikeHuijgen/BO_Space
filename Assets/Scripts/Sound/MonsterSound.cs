using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] monsterAudio;
    private AudioClip monsterSound;

    private bool canPlaySound;

    // Start is called before the first frame update
    void Start()
    {
        canPlaySound = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayClips();
    }


    private void PlayClips()
    {
        //als de audio niet meer speeld en de timer is op true geeft hij een nieuwe audioClip
        if (!audioSource.isPlaying && canPlaySound)
        {
            int index = Random.Range(0, monsterAudio.Length);
            monsterSound = monsterAudio[index];
            audioSource.clip = monsterSound;
            canPlaySound = false;
            audioSource.Play();
            StartCoroutine(SoundTimer());
        }
    }

    IEnumerator SoundTimer()
    {
        yield return new WaitForSeconds(2);
        canPlaySound = true;
    }

}

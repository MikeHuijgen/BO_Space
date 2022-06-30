using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private PlayerDeath playerDeath;
    private float elapsedTime;
    [SerializeField] AudioClip monsterEating;
    private AudioSource audioSource;

    // Update is called once per frame
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator Shake()
    {
        Vector3 startPos = transform.localPosition;
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            float x = Random.Range(-.5f, .5f) * strength;
            float y = Random.Range(-.5f, .5f) * strength;
            transform.localPosition = new Vector3(x, y, startPos.z);
            yield return null;
        }

        transform.localPosition = startPos;
        Time.timeScale = 0;
        audioSource.clip = monsterEating;
        audioSource.Play();
    }
}

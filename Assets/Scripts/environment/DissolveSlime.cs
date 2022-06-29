using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSlime : MonoBehaviour
{
    [SerializeField] private float dissolveSpeed;
    [SerializeField] private ParticleSystem smokePartical;
    [SerializeField] private AudioClip burnSound;
    [SerializeField] private AudioClip slimeSound;

    private Material dissolveShader;
    [SerializeField] private float maxLifetime;
    private bool dissolve = false;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dissolveShader = GetComponent<Renderer>().material;
        maxLifetime = 1f;
        audioSource.clip = slimeSound;
        audioSource.Play();
    }

    private void Update()
    {
        DestroySlime();
        Dissolve();
    }

    public void DissolveHit(bool gotHit)
    {
        if (gotHit == true)
        {
            audioSource.Stop();
            audioSource.clip = burnSound;
            audioSource.Play();
            smokePartical.Play();
            dissolve = true;
        }
    }

    void Dissolve()
    {
        // It activate the shader to dissolve if dissolve is true
        if (dissolve == true)
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            maxLifetime -= dissolveSpeed * Time.deltaTime;
            dissolveShader.SetFloat("Lifetime", maxLifetime);
        }
    }

    void DestroySlime()
    {
        if (maxLifetime < 0f)
        {
            audioSource.Stop();
            smokePartical.Stop();
            Destroy(gameObject);
        }
    }
}

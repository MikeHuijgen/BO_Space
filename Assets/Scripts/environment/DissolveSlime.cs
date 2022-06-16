using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSlime : MonoBehaviour
{
    [SerializeField] private float dissolveSpeed;
    [SerializeField] private ParticleSystem smokePartical;

    private Material dissolveShader;
    private float maxLifetime;
    private bool dissolve = false;

    private void Start()
    {
        dissolveShader = GetComponent<Renderer>().material;
        maxLifetime = 1f;
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
            smokePartical.Stop();
            Destroy(gameObject);
        }
    }
}

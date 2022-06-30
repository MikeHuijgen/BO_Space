using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollider : MonoBehaviour
{
    [SerializeField] FlashLight flashLight;
    private Collider monsterCollider;

    void Start()
    {
        monsterCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        ToggleCollider();
    }

    void ToggleCollider()
    {
        if (flashLight.lightTurnedUn)
        {
            monsterCollider.enabled = true;
        }
        else
        {
            monsterCollider.enabled = false;
        }
    }
}

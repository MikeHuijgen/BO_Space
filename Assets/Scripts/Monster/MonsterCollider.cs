using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCollider : MonoBehaviour
{
    [SerializeField] FlashLight flashLight;
    private BoxCollider monsterCollider;

    void Start()
    {
        monsterCollider = GetComponent<BoxCollider>();
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

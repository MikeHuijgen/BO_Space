using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedMovement : MonoBehaviour
{

    [SerializeField] private float speed = 12f;

    CapsuleCollider col;

    void Start()
    {
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        { 
            col.height = 1;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            col.height = 2;
        }
        

    }
   

   
}

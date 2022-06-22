using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AdvancedMovement : MonoBehaviour
{ 

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            transform.localScale = new Vector3(0.5f, 0.7f, 0.5f);
            transform.position += Vector3.down * 0.6f;
        }
        if (Input.GetButtonUp("Crouch"))
        {
            transform.localScale = new Vector3(0.5f, 1f, 0.5f);
            transform.position += Vector3.up * 0.6f;
        }
    }
   

   
}

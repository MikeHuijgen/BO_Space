using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedMovement : MonoBehaviour
{

    public float speed = 12f;


    BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        { 
            col.size = new Vector3(1f, .3f, 1f);

        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            col.size = new Vector3(1f, 1f, 1f);

        }
        

    }
   

   
}

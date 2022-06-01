using UnityEngine;

public class walk : MonoBehaviour
{
    CharacterController characterController;
        public float speed;
        Vector3 mousePos;
     
        void Start ()
        {
             
        }
         
        void Update ()
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.LookAt (mousePos);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, transform.localEulerAngles.z);
     
            if (Input.GetMouseButton(0))
                 transform.position += (-transform.position + mousePos).normalized * speed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
}




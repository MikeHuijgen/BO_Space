    using UnityEngine;
     
    public class fpcontroller : MonoBehaviour {
    public int moveSpeed = 3f;
    public int moveDirection = 3f;
    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        ms();
    }

    void ms()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed *  10f, ForceMode.Force);
    }
    }
     

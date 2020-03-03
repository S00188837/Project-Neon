using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerController
{
    public Rigidbody Rigid;

    public float JumpForce;
    public float MoveSpeed;

    private void FixedUpdate()
    {

        Move();

        if (isGrounded == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }

    }

    public void Move()
    {
        {
            Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
        }
    }

    void Jump()
    {
        Rigid.AddForce(transform.up * JumpForce);
    }

}

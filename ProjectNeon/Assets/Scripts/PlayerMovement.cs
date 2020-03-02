using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody Rigid;
    public float MoveSpeed;
    public float JumpForce;


    private void FixedUpdate()
    {
        Move();

        if (Input.GetKey(KeyCode.Space))
            Rigid.AddForce(transform.up * JumpForce);
    }

    public void Move()
    {
        {
            Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
        }
    }

}

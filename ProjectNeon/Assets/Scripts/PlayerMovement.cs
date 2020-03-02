using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerController
{
    public Rigidbody Rigid;
    JetPack jetpack;

    public float MoveSpeed;
    public float FlyForce;

    private void Start()
    {
        jetpack = GetComponent<JetPack>();
    }

    private void FixedUpdate()
    {
        Move();
        jetpack.FixedUpdate();
    }

    public void Move()
    {
        {
            Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
        }
    }

}

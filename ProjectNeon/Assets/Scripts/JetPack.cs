using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : PlayerController
{
    public Rigidbody Rigid;

    public float FlyForce;

    public float MaxFuel = 300;
    public float Fuel = 0;
    public float FuelConsumption = 2;



    private void Start()
    {
        Fuel = MaxFuel;
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && Fuel >= FuelConsumption && isGrounded == false)
        {
            Rigid.AddForce(transform.up * FlyForce);
            Fuel -= FuelConsumption;
        }

        if (Fuel < MaxFuel && !Input.GetKey(KeyCode.Space))
        {
            Fuel += 1f;
        }
    }

   
}

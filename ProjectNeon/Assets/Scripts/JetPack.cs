using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : PlayerController
{
    PlayerMovement movement;

    public float MaxFuel = 300;
    public float Fuel = 0;
    public float FuelConsumption = 2;



    private void Start()
    {
        Fuel = MaxFuel;
        movement = GetComponent<PlayerMovement>();
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && Fuel >= FuelConsumption)
        {
            movement.Rigid.AddForce(transform.up * movement.FlyForce);
            Fuel -= FuelConsumption;
        }

        if (Fuel < MaxFuel && !Input.GetKey(KeyCode.Space))
        {
            Fuel += 1f;
        }
    }

   
}

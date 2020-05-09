using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    PlayerController controller;
    public Rigidbody Rigid;

    public float FlyForce;

    public float MaxFuel = 300;
    public float Fuel = 0;
    public float FuelConsumption = 2;



    private void Start()
    {
        controller = GetComponent<PlayerController>();
        Fuel = MaxFuel;
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && Fuel >= FuelConsumption && controller.isGrounded == false)
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

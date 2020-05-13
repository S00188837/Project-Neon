using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    HealthComponent healthComponent;
    

    public Transform HealthText;


    Rigidbody rigid;
    public float force = -10;

    Transform health1;
    Transform health2;
    Transform health3;
    Transform health4;

    public enum PlayerStates
    {
        OnGround,
        InAir,
        Shooting,
        Dead
    }

    public PlayerStates playerState;

    public bool isGrounded = false;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        healthComponent = GetComponent<HealthComponent>();
        

        HealthText.GetComponent<Text>().text = healthComponent.Health.ToString();
        playerState = PlayerStates.OnGround;

        health1 = GameObject.FindGameObjectWithTag("Health1").transform;
        health2 = GameObject.FindGameObjectWithTag("Health2").transform;
        health3 = GameObject.FindGameObjectWithTag("Health3").transform;
        health4 = GameObject.FindGameObjectWithTag("Health4").transform;
    }

    private void Update()
    {
        HealthText.GetComponent<Text>().text = healthComponent.Health.ToString();


        if (healthComponent.Health == 75)
        {
            health1.gameObject.SetActive(false);
        }
        else if (healthComponent.Health == 50)
        {
            health2.gameObject.SetActive(false);
        }
        else if (healthComponent.Health == 25)
        {
            health3.gameObject.SetActive(false);
        }
        else if (healthComponent.Health == 0)
        {
            health4.gameObject.SetActive(false);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            playerState = PlayerStates.OnGround;
        }

        if (collision.gameObject.tag == "Boss")
        {
            healthComponent.ApplyDamage(25);

            rigid.AddForce(transform.forward * force, ForceMode.Impulse);

        }

    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
            playerState = PlayerStates.InAir;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AmmoBox")
        {
            

            Destroy(other.gameObject);

        }
    }
}




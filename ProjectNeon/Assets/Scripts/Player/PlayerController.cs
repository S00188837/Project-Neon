using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

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
        playerState = PlayerStates.OnGround;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            playerState = PlayerStates.OnGround;
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
}




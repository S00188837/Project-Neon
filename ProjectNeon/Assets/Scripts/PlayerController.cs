using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerStates
    {
        Idle,
        Walking,
        Flying,
        Shooting,
        Dead
    }

    public PlayerStates playerState;

    bool isGrounded;

    private void Start()
    {
        playerState = PlayerStates.Idle;
    }

    private void FixedUpdate()
    {
        
    }

}

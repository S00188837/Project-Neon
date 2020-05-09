using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : NavMeshMover
{
    HealthComponent health;

    public override void Start()
    {
        health = GetComponent<HealthComponent>();
        base.Start();
    }


    void Update()
    {
        if (health.Health <= 1000)
        {
            agent.speed = 10;
        }
    }
}

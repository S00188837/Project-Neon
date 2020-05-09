using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhase : MonoBehaviour
{
    Light LT;
    Renderer renderer;
    Color color1 = Color.red;
    public Material redNeon;

    HealthComponent health;

    void Start()
    {
        LT = GetComponent<Light>();
        renderer = GetComponent<Renderer>();
        health = gameObject.GetComponentInParent<HealthComponent>();
    }

    
    void Update()
    {
        if (health.Health <= 1000)
        {
            LT.color = color1;
            renderer.material = redNeon;
        }
    }
}

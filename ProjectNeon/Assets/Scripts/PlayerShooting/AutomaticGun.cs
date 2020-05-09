using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticGun : RayCastWeapon
{

    public override void Fire(Ray fireFromPosition)
    {
        if (Physics.Raycast(fireFromPosition, out raycastHit))
        {
            Debug.DrawRay(fireFromPosition.origin, fireFromPosition.direction, Color.red, 15);

            HealthComponent health = raycastHit.collider.GetComponent<HealthComponent>();

            if (health)
            {
                ApplyDamage(health);
            }

            if (Input.GetMouseButtonDown(0))
            {
                base.Fire(fireFromPosition);
            }
        }
        
    }
}

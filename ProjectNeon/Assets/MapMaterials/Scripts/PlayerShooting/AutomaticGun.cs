using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticGun : RayCastWeapon
{

    public override void Fire(Ray fireFromPosition)
    {
        if (Physics.Raycast(fireFromPosition, out raycastHit, Range))
        {
            Debug.DrawRay(fireFromPosition.origin, fireFromPosition.direction * Range, Color.red, 15);
            HealthBar health = raycastHit.collider.GetComponent<HealthBar>();

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

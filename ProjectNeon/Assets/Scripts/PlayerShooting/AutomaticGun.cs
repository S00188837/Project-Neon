using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticGun : RayCastWeapon
{

    public override void Fire(Vector3 fireFromPosition)
    {
        if (Physics.Raycast(fireFromPosition, transform.forward, out raycastHit, Range))
        {

            HealthComponent health = raycastHit.collider.GetComponent<HealthComponent>();

            if (health)
            {
                ApplyDamage(health);
            }

            base.Fire(fireFromPosition);
        }
        
    }
}

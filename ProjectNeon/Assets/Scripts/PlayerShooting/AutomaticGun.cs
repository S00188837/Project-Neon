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

            GameObject FF = Instantiate(bulletHole, raycastHit.point + (raycastHit.normal * 0.025f), Quaternion.FromToRotation(Vector3.forward, raycastHit.normal), raycastHit.collider.transform);

            Destroy(FF, 2.0f);
            

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : Weapon
{
    protected RaycastHit raycastHit;
    public float Range;
    public float DamagePerHit;

    protected void ApplyDamage(HealthComponent healthComponent)
    {
        healthComponent.ApplyDamage(DamagePerHit);
    }
}

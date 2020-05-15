using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : Weapon
{
    protected RaycastHit raycastHit;
    public float Range;
    public int DamagePerHit;

    protected void ApplyDamage(HealthComponent healthcomponent)
    {
        healthcomponent.ApplyDamage(DamagePerHit);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon[] weapons;
    int activeWeaponIndex = -1;
    Weapon activeWeapon;

    private void Start()
    {
        if (activeWeapon == null)
        {
            SetActiveWeapon(0);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            activeWeapon.Fire(transform.position);
        }
    }

    private void HandleWeaponSwitching()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveWeapon(1);
        }
    }

    private void SetActiveWeapon(int index)
    {
        if (index != activeWeaponIndex)
        {
            if (index >= 0 && index <= weapons.Length)
            {
                if (activeWeapon)
                {
                    Destroy(activeWeapon.gameObject);
                }

                activeWeapon = Instantiate(weapons[index], transform);
                activeWeaponIndex = index;
            }
        }
    }
}

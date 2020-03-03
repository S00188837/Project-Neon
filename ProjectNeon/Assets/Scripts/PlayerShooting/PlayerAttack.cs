using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon[] weapons;
    int activeWeaponIndex = -1;
    Weapon activeWeapon;

    public GameObject bullet;
    public GameObject Location;

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

            if (activeWeaponIndex == 0)
            {
                GameObject g = (GameObject)Instantiate(bullet, Location.transform.position, Quaternion.identity);

                float force = g.GetComponent<Bullet>().speed;
                g.GetComponent<Rigidbody>().AddForce(g.transform.forward * force);
            }
            
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

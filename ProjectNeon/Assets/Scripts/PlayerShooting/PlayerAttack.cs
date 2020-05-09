using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Weapon[] weapons;
    int activeWeaponIndex = -1;
    Weapon activeWeapon;

    public Transform bulletText;
    public Transform bulletTextMAX;

    public GameObject bulletHole;
    protected RaycastHit raycastHit;

    private void Start()
    {
        if (activeWeapon == null)
        {
            SetActiveWeapon(0);
        }

        bulletText.GetComponent<Text>().text = activeWeapon.Magazine.ToString();
        bulletTextMAX.GetComponent<Text>().text = activeWeapon.Magazine.ToString();

    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && activeWeapon.Magazine >= 1)
        {
            activeWeapon.Fire(Camera.main.ScreenPointToRay(Input.mousePosition));

            bulletText.GetComponent<Text>().text = activeWeapon.Magazine.ToString();

            if (Physics.Raycast(transform.position, -Vector3.up, out raycastHit))
            {
                GameObject decalObject = Instantiate(bulletHole, raycastHit.point + (raycastHit.normal * 0.025f), Quaternion.FromToRotation(Vector3.forward, raycastHit.normal));
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

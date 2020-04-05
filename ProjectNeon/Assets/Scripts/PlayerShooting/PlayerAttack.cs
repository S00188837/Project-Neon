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



    private void Start()
    {
        if (activeWeapon == null)
        {
            SetActiveWeapon(0);
        }

        bulletText.GetComponent<Text>().text = activeWeapon.Magazine.ToString();
        bulletTextMAX.GetComponent<Text>().text = activeWeapon.Magazine.ToString();

    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && activeWeapon.Magazine >= 1)
        {
            activeWeapon.Fire(Camera.main.ScreenPointToRay(Input.mousePosition));

            bulletText.GetComponent<Text>().text = activeWeapon.Magazine.ToString();
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

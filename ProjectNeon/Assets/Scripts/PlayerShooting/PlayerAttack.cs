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
    public Transform[] Health;

    public int index = 2;


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
            activeWeapon.Fire(transform.position);

            bulletText.GetComponent<Text>().text = activeWeapon.Magazine.ToString();
        }

        UsedMag();
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

    void UsedMag()
    {
        if (activeWeapon.Magazine <= 1)
        {
            if (activeWeapon.MagLeft > 0)
            {
                Health[index].gameObject.active = false;
                index--;
                Debug.Log("mag gone");
            }
        }
    }
}

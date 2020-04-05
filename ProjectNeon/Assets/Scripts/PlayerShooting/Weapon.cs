using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public int MaxReserves = 80;
    public int Reserves;

    public int MaxMagazine = 20;
    public int Magazine;

    public int MagLeft = 3;

    public int AmmoUsedPerShot = 1;
    public bool IsAutomatic;

    Transform ammo1;
    Transform ammo2;
    Transform ammo3;

    public virtual void Start ()
    {
        Magazine = MaxMagazine;
        Reserves = MaxReserves;

        ammo1 = GameObject.FindGameObjectWithTag("Ammo").transform;
        ammo2 = GameObject.FindGameObjectWithTag("Ammo1").transform;
        ammo3 = GameObject.FindGameObjectWithTag("Ammo2").transform;

    }
	
	public virtual void Fire(Ray fireFromPosition)
    {
        Magazine = Magazine - AmmoUsedPerShot;

        if (Magazine <= 0 && MagLeft > 0)
        {
            Reload();
            MagLeft--;
        }
    }

    public bool HasAmmo()
    {
        return Magazine >= AmmoUsedPerShot;
    }

    public void Reload()
    {
        if (Reserves >= MaxMagazine)
        {
            Magazine = MaxMagazine;
            UsedMag();
        }
        else if (Reserves < MaxMagazine)
        {
            Magazine = MaxMagazine - Reserves;
            UsedMag();
        }
    }

    void UsedMag()
    {
        if (MagLeft == 3)
        {
            ammo3.gameObject.SetActive(false);
        }
        else if (MagLeft == 2)
        {
            ammo2.gameObject.SetActive(false);
        }
        else if (MagLeft == 1)
        {
            ammo1.gameObject.SetActive(false);
        }
    }
}

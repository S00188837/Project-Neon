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

	void Start ()
    {
        Magazine = MaxMagazine;
        Reserves = MaxReserves;
	}
	
	public virtual void Fire(Vector3 fireFromPosition)
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
        }
        else if (Reserves < MaxMagazine)
        {
            Magazine = MaxMagazine - Reserves;
        }
    }
}

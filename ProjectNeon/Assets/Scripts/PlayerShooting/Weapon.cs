using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int MaxReserves = 120;
    public int Reserves;

    public int MaxMagazine = 24;
    public int Magazine;

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
        if (Magazine <= 0)
        {
            Reload();
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

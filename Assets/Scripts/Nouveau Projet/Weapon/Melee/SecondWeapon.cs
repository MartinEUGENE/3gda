using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWeapon : WeaponSystem
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Shoot()
    {
        base.Shoot();
        GameObject Melee = Instantiate(weaponData.PrefabObj);
        Melee.transform.position = transform.position;
        Melee.transform.parent = transform.parent;
        Melee.transform.rotation = transform.rotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWeapon : WeaponSystem
{
    protected override void Start()
    {

    }


    protected override void Shoot()
    {
        base.Shoot();
        GameObject Melee = Instantiate(prefabObj);
        Melee.transform.position = transform.position;
        Melee.transform.parent = transform;
    }


}

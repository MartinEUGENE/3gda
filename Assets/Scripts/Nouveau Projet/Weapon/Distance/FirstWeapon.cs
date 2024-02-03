using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWeapon : WeaponSystem
{   
    //CharactControls player; 

    protected override void Start()
    {
        base.Start();
        //player = GetComponentInParent<CharactControls>();
        cooldown = weaponReload; 
    }

    void FixedUpdate()
    {

    }

    protected override void Shoot()
    {
        base.Shoot();
        GameObject SpawnedAttack = Instantiate(prefabObj);
        SpawnedAttack.transform.position = transform.position;
        SpawnedAttack.GetComponent<BulletSystem>().DirChecker(chara.lastMovVector);
    }


}

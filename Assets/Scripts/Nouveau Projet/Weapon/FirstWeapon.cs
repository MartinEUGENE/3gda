using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWeapon : WeaponSystem
{

    [SerializeField] GameObject rightAttack;
    [SerializeField] GameObject leftAttack;

    CharactControls player; 

    void Start()
    {
        player = GetComponentInParent<CharactControls>();
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown<0f)
        {
            Shoot();
        }
    }


    public override void Shoot()
    {
        Debug.Log("Attack");
        cooldown = weaponReload;


        if(player.lastMovHorizon < 0)
        {
            rightAttack.SetActive(true);
        }

        else
        {
            leftAttack.SetActive(true);
        }
    }
}

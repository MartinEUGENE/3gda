using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponStats weaponData;



    [Header("Prefab Stored")]
    protected CharactControls chara;

    [Header("Weapon Level")]
    public int level = 1;
    protected virtual void Start()
    {
        chara = FindObjectOfType<CharactControls>();
    }

    protected virtual void Shoot()
    {
        weaponData.cooldown = weaponData.WeaponReload; 
    }

    protected virtual void Update()
    {
        weaponData.cooldown -= Time.deltaTime;

        if (weaponData.cooldown <= 0f)
        {
            Shoot();
        }
    }

}

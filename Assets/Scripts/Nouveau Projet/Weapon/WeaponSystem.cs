using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public enum WeaponType
    {
        CloseRange,
        MidRange,
        LongRange,
        AreaWeapon
    }


    [Header("Weapon Stats")]
    public WeaponStats weaponData;
    public WeaponType weaponType;

    [Header("Prefab Stored")]
    protected CharactControls chara;
    public Camera mainCam;
    public Vector3 mousPos;


    [Header("Weapon Level")]
    public int currentLevel = 1;
    protected virtual void Start()
    {
        chara = FindObjectOfType<CharactControls>();
        mainCam = FindObjectOfType<Camera>();
    }

    protected virtual void Shoot()
    {
        weaponData.cooldown = weaponData.WeaponReload; 
    }

    public void GetALevelUp(WeaponStats weapon)
    {
        weaponData = weapon;
    }

    protected virtual void Update()
    {
        weaponData.cooldown -= Time.deltaTime;

        if (weaponData.Cooldown <= 0f)
        {
            Shoot();
        }
    }

}



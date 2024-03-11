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
    public int level = 1;
    protected virtual void Start()
    {
        chara = FindObjectOfType<CharactControls>();
        mainCam = FindObjectOfType<Camera>();
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

        /*mousPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousPos - transform.position;
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot);*/

    }

}



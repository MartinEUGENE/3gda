using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{

    [Header("Weapon Stats")]
    public int damage = 5; 
    public float speedrange = 3f;
    public float cooldown = 0f;
    public float weaponReload = 2f;

    public int pierceEffect = 3; 

    [Header("Prefab Stored")]
    public GameObject prefabObj;
    protected CharactControls chara; 

    [Header("Weapon Level")]
    public int level = 1;

    protected virtual void Start()
    {
        chara = FindObjectOfType<CharactControls>();
    }

    protected virtual void Shoot()
    {
        cooldown = weaponReload;
    }

    protected virtual void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown < 0f)
        {
            Shoot();
        }
    }

}

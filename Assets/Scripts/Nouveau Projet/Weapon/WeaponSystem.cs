using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{

    [Header("Weapon Stats")]
    public int damage = 5; 
    public float speedrange = 3f;
    public float cooldown;
    public float weaponReload;

    public bool pierceEffect = true; 

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
        cooldown = cooldown - Time.deltaTime;

        if (cooldown <= 0f)
        {
            Shoot();
        }
    }

}

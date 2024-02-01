using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{

    [Header("Weapon Stats")]
    public int damage = 5; 
    public  int range = 1;
    public float cooldown = 1.0f;
    public float weaponReload = 2f;

    [Header("Weapon Level")]
    public int level = 1;

    public virtual void Shoot()
    {

    }

}

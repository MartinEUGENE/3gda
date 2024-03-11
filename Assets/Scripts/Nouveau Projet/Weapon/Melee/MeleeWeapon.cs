using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public Vector3 mousPos;
    public float destroyObj = 2f;
    //public Camera mainCam;

    public CharacterStats stats;
    public WeaponStats weapon;
    protected virtual void Start()
    {
        Destroy(gameObject, destroyObj);
        stats = GetComponentInParent<CharacterStats>();
    }

    public int GetCurrentDamage()
    {
        return stats.currentAttack + weapon.damage;
    }

}

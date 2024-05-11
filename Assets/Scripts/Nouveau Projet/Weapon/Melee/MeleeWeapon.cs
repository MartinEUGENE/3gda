using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public Vector3 mousPos;
    public float destroyObj = 2f;
    //public Camera mainCam;
    public int inateCrit;

    public bool hasCrit; 


    public CharacterStats stats;
    public WeaponStats weapon;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyObj);
        stats = GetComponentInParent<CharacterStats>();
        OnSpawn(); 
    }
    protected virtual void Update()
    {
        inateCrit = Random.Range(1, 100);
    }

    public int GetCurrentDamage()
    {
        int dmgResult = stats.currentAttack + weapon.Damage;

        if (stats.currentCriticalRate >= inateCrit)
        {
            dmgResult *= Mathf.FloorToInt(stats.currentCriticalDmg);
            hasCrit = true; 
        }

        else
        {
            dmgResult = stats.currentAttack + weapon.Damage;
            hasCrit = false;
        }

        return dmgResult;

    }


   protected virtual void OnSpawn()
   {

   }
}

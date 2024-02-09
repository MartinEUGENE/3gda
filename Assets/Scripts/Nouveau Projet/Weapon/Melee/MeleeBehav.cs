using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehav : MeleeWeapon
{
    protected override void Start()
    {
        base.Start();
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemiesSystem en = other.GetComponent<EnemiesSystem>();
            en.TakeDmg(weapon.Damage);
        }
    }

}

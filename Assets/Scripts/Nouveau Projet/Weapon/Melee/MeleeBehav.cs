using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehav : MeleeWeapon
{
    List<GameObject> markedEnemies; 

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
            EnemiesSystem en = other.GetComponent<EnemiesSystem>();
            en.TakeDmg(weapon.Damage);
            markedEnemies.Add(other.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehav : MeleeWeapon
{
    List<GameObject> markedEnemies;
    WeaponSystem wetNoodle; 

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
            EnemiesSystem enemy = other.GetComponent<EnemiesSystem>();
            enemy.TakeDmg(GetCurrentDamage(), hasCrit);
            markedEnemies.Add(other.gameObject);
        }
    }
}

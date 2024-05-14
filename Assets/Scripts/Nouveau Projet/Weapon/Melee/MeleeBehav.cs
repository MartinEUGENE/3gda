using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehav : MeleeWeapon
{
    List<GameObject> markedEnemies;
    WeaponSystem wetNoodle;
    Animator animate;


    protected override void Start()
    {
        base.Start();
        animate = GetComponent<Animator>(); 
        markedEnemies = new List<GameObject>();
        OnSpawn(); 
    }

    protected override void Update()
    {
        base.Update(); 
        //animate.Play("Batting");
    }

    protected override void OnSpawn()
    {
        base.OnSpawn();
        FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Player/Weapon/Main Weapons/Bat_Weapon");
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
            EnemiesSystem enemy = other.GetComponent<EnemiesSystem>();

            enemy.knockDuration = weapon.KnockbackDuration;
            enemy.knockForce = weapon.Knockback;

            enemy.TakeDmg(GetCurrentDamage(), hasCrit);
            markedEnemies.Add(other.gameObject);
        }
    }
}

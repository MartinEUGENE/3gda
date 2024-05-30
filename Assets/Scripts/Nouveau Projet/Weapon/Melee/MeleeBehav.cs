using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBehav : MeleeWeapon
{
    WeaponSystem wetNoodle;
    Animator animate;

    private FMOD.Studio.EventInstance meleeHit; 

    protected override void Start()
    {
        base.Start();
        animate = GetComponent<Animator>(); 
        markedEnemies = new List<GameObject>();
        OnSpawn();

        meleeHit.start(); 
    }

    protected override void Update()
    {
        base.Update(); 
    }

    protected override void OnSpawn()
    {
        base.OnSpawn();
        meleeHit = FMODUnity.RuntimeManager.CreateInstance("event:/New Project/Player/Weapon/Main Weapons/Bat_Weapon");
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
            meleeHit.setParameterByNameWithLabel("WasHit", "Yes"); 
            EnemiesSystem enemy = other.GetComponent<EnemiesSystem>();

            enemy.knockDuration = weapon.KnockbackDuration;
            enemy.knockForce = weapon.Knockback;

            enemy.TakeDmg(GetCurrentDamage(), hasCrit);
            markedEnemies.Add(other.gameObject);
        }
    }
}

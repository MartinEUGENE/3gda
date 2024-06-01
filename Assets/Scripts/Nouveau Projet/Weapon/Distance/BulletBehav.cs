using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehav : BulletSystem
{
    List<GameObject> markedEnemies;
    private FMOD.Studio.EventInstance distHit;


    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
    
        Vector2 dir = moveDir; 
        rb.velocity = new Vector2(dir.x, dir.y) * weapon.Speedrange;
        distHit = FMODUnity.RuntimeManager.CreateInstance("event:/New Project/Player/Weapon/Main Weapons/Brick_Weapon");

        OnSpawn();
    }

    protected override void OnSpawn()
    {
        distHit.start(); 
    }

    protected override void Update()
    {
        base.Update();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
            EnemiesSystem en = other.GetComponent<EnemiesSystem>();

            en.knockDuration = weapon.KnockbackDuration;
            en.knockForce = weapon.Knockback;
            FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Player/Weapon/Main Weapons/BrickHit", transform.position); 
            en.TakeDmg(GetCurrentDamage(), hasCrit);         
        }
    }
}

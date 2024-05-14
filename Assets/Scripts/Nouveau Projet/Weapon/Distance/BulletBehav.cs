using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehav : BulletSystem
{
    List<GameObject> markedEnemies;

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
        OnSpawn(); 
        Vector2 dir = moveDir; 
        rb.velocity = new Vector2(dir.x, dir.y) * weapon.Speedrange; 
    }

    protected override void OnSpawn()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Player/Weapon/Main Weapons/Brick_Weapon");
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

            FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Player/Weapon/Main Weapons/ContactWith/Brick_Contact"); 
            en.TakeDmg(GetCurrentDamage(), hasCrit);         
        }
    }
}

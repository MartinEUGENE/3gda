using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookProjectile : MeleeWeapon
{
    private Transform form;
   protected override void Start()
   {
        base.Start();
        markedEnemies = new List<GameObject>();
        form = gameObject.transform;
   }

    protected override void Update()
    {
        base.Update(); 
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    protected override void OnSpawn()
    {
        FMODUnity.RuntimeManager.PlayOneShot("");
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

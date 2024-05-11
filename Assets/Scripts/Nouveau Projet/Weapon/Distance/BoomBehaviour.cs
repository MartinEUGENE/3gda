using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBehaviour : BulletSystem
{
    List<GameObject> markedEnemies;
    public int countDown = 0;
    public int countStop = 200; 

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();
    }

    protected override void Update() 
    {
        base.Update();
        countDown += 1;

        if (countDown >= countStop)
        {
            Destroy(gameObject);
        }
        
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
            EnemiesSystem en = other.GetComponent<EnemiesSystem>();

            en.knockDuration = weapon.KnockbackDuration;
            en.knockForce = weapon.Knockback;

            en.TakeDmg(GetCurrentDamage(), hasCrit);
            markedEnemies.Add(other.gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBehaviour : BulletSystem
{
    List<GameObject> markedEnemies;
    public int countDown = 0;

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();

    }

    protected override void Update() 
    {
        base.Update();
        countDown += 1;
        if (countDown >= 200)
        {
            Destroy(gameObject);
        }
        
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
            EnemiesSystem en = other.GetComponent<EnemiesSystem>();
            en.TakeDmg(GetCurrentDamage(), hasCrit);
            //Debug.Log(GetCurrentDamage());
            markedEnemies.Add(other.gameObject);
        }
    }
    public int GetCurrentDamage()
    {
        return stats.currentAttack + weapon.damage;
    }
}

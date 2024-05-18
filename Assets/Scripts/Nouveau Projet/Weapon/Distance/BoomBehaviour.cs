using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBehaviour : BulletSystem
{
    public List<GameObject> markedEnemies;
    protected override void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        stats = GetComponentInParent<CharacterStats>();
        OnSpawn(); 
        markedEnemies = new List<GameObject>();
        Destroy(gameObject, destroyObj); 
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

            en.TakeDmg(GetCurrentDamage(), hasCrit);
            markedEnemies.Add(other.gameObject);
        }
    }
}

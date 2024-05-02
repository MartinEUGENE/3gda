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
        //moveDir = mainCam.ScreenToWorldPoint(Input.mousePosition); 
        Vector2 dir = moveDir; 
        rb.velocity = new Vector2(dir.x, dir.y) * weapon.Speedrange; 
    }

    protected override void Update() 
    {
        base.Update();
        //transform.position += moveDir * weapon.speedrange * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
                EnemiesSystem en = other.GetComponent<EnemiesSystem>();
                en.TakeDmg(GetCurrentDamage(), hasCrit);         
        }
    }
}

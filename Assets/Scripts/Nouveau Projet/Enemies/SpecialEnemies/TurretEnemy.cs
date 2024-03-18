using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : EnemiesSystem
{
    public GameObject bullet;
    float internalTiming;
    public int bulletNb;
    public int bulletTick = 0;


    public override void Awake()
    {
        base.Awake();
        bulletNb = 3; 
    }
    public override void OnSpawn()
    {
        base.OnSpawn();
    }

    public override void EnemyAttack()
    {
        base.EnemyAttack();

        Vector2 direction = playerVector - transform.position;
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    public override void Update()
    {
        base.Update();
        internalTiming += Time.deltaTime;

        if(internalTiming >= currentTiming /*&& bulletTick < bulletNb*/)
        {
            EnemyAttack();
            internalTiming = 0f;
            //bulletTick++; 
        }

    }

    public override void EnemyMove()
    {
        base.EnemyMove();
    }
}

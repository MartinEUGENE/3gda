using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : EnemiesSystem
{
    public GameObject bullet;
    public float internalTiming;
    public int bulletNb;
    public int bulletTick = 0;


    public override void Awake()
    {
        base.Awake();
        bulletNb = 3;
        currentTiming = stats.EnemyTiming;
    }
    public override void OnSpawn()
    {
        base.OnSpawn();
    }
    public override void Update()
    {
        base.Update();
        internalTiming += Time.deltaTime;

        if (internalTiming >= currentTiming /*&& bulletTick < bulletNb*/)
        {
            StartCoroutine(TrueShot());
            internalTiming = 0f;
            //bulletTick++; 
        }
    }

    IEnumerator TrueShot()
    {
        yield return new WaitForSeconds(0.5f);

        Vector2 direction = playerVector - transform.position;
        Instantiate(bullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.1f);         
    }

    public override void EnemyMove()
    {
        base.EnemyMove();
    }
}

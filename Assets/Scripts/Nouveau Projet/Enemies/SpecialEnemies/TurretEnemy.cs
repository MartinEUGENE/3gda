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

    public override void FixedUpdate()
    {
        Vector2 direction = (playerObj.transform.position - transform.position).normalized;

        if (direction.x != 0)
        {
            lastMovHorizon = direction.x;
            moving.x = direction.x;
        }

        if (direction.y != 0)
        {
            lastMovVertical = direction.y;
            moving.y = direction.y;
        }
    }

    IEnumerator TrueShot()
    {
        yield return new WaitForSeconds(.5f);
        FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Enemy/Turret Enemy/Turret_Shoot");
        Vector2 direction = playerVector - transform.position;
        Instantiate(bullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.5f);         
    }

    public override void EnemyMove()
    {
        base.EnemyMove();
    }
}

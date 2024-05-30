using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeEnemies : EnemiesSystem
{
    bool dead = false;

    [Header("Stat of the movement part")]
    public Vector2 goThere; 
    public float mov;
    public float startingTime;
    public float dist;
    Transform horde; 

    public override void OnSpawn()
    {
        base.OnSpawn();
        StartCoroutine(TowardTheGoal());
    }

    public override void Update()
    {
        if(dead == true)
        {
            Die();
        }
    }

    public override void FixedUpdate()
    {
       if(dead)
       {
            base.FixedUpdate();
       }
    }

    public IEnumerator TowardTheGoal()
    {
        yield return new WaitForSeconds(startingTime);
        rb2d.velocity = new Vector2(goThere.x, goThere.y).normalized * mov;
        if(goThere.x<0)
        {
            horde.localScale = new Vector3(-1f, 1f, 1f);  
        }
        yield return new WaitForSeconds(dist);

        dead = true;
    }

}

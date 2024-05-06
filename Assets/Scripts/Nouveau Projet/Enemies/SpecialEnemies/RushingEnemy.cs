using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RushingEnemy : EnemiesSystem
{
    public float startingTime;
    public LineRenderer prediction;
    Transform AHA; 

    Vector2 playerDir;



    int dist = 15; 
    public float rushForce; 
    public float rushDist;
    float timing; 

    bool dead = false;
    public override void Awake()
    {
        base.Awake();
    }
    public override void OnSpawn()
    {
        base.OnSpawn();
        AHA = GetComponent<Transform>();
        prediction = GetComponent<LineRenderer>(); 
        
        timing = rushDist;
        StartCoroutine(Rush());        
    }

    public override void FixedUpdate()
    {

    }

    public override void Update()
    {
        playerDir = playerObj.transform.position - transform.position;
        prediction.SetPosition(1, 5 * playerDir);

        if (dead == true)
        {
            Die();
        }
    }

    public IEnumerator Rush()
    {
        yield return new WaitForSeconds(startingTime);
        prediction.enabled = false;
        rb2d.velocity = new Vector2(playerDir.x, playerDir.y).normalized * rushForce;
        yield return new WaitForSeconds(rushDist);
               
        dead = true;        
    }

}

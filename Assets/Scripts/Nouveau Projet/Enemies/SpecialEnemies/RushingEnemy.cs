using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RushingEnemy : EnemiesSystem
{
    public float startingTime;
    public LineRenderer prediction;
    Transform AHA; 

    Vector2 playerDir;

    Animator anime;
    CharactControls ch;
    SpriteRenderer sp;

    int dist = 15; 
    public float rushForce; 
    public float rushDist;
    float timing; 

    bool dead = false;
    public override void Awake()
    {
        base.Awake();

        anime = GetComponent<Animator>();
        anime.SetBool("IsMoving", false);

        
        ch = FindObjectOfType<CharactControls>();
        sp = GetComponent<SpriteRenderer>();
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

        if (ch.moving.x != 0 || ch.moving.y != 0)
        {
            SpriteFlipper();
        }

        if (dead == true)
        {
            Die();
        }
    }

    void SpriteFlipper()
    {
        if (ch.lastMovHorizon < 0)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }

    }

    public IEnumerator Rush()
    {
        /*yield return new WaitForSeconds(.1f);
        prediction.enabled = false;
        yield return new WaitForSeconds(.1f);
        prediction.enabled = true;
        yield return new WaitForSeconds(.1f);*/
        yield return new WaitForSeconds(startingTime - .2f);
        prediction.enabled = false;
        anime.SetBool("IsMoving", true);
        rb2d.velocity = new Vector2(playerDir.x, playerDir.y).normalized * rushForce;
        yield return new WaitForSeconds(rushDist);
               
        dead = true;        
    }

}

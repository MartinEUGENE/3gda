using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueBoss : EnemiesSystem
{
    [Header("Stats")]
    [Range(0,3)]public int patternAttack = 0;
    public float attackTiming;
    public float recoverTiming;
    bool canAttack; 

    [Header("The Laser")]
    Vector2 playerDir;
    public GameObject laser; 
    public Transform[] ponties;
    

    public void Start()
    {
        recoverTiming = attackTiming; 
    }

    public override void Awake()
    {
        base.Awake();
        playerDir = playerObj.transform.position - transform.position; 
    }

    public override void Update()
    {
        //patternAttack = Random.Range(1, 4);
        recoverTiming -= Time.deltaTime; 

        if(recoverTiming <= 0f)
        {
            canAttack = true; 
            recoverTiming = attackTiming;
        }

        if(/*patternAttack == 1 && canAttack*/ canAttack)
        {
            RushAttack();            
        }

        /*else if(patternAttack == 2 && canAttack)
        {
            BigLaser(); 
        }*/

        Debug.Log(patternAttack);
    }

    
    public IEnumerator RushAttack()
    {
        yield return new WaitForSeconds(stats.EnemyTiming);
        rb2d.velocity = new Vector2(playerDir.x, playerDir.y).normalized * attackTiming;
        yield return new WaitForSeconds(10f);

        canAttack = false; 
    }

   /* public IEnumerator BigLaser()
    {
        yield return new WaitForSeconds(stats.EnemyTiming);
    }*/
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class LevelRange
{
    public int startingLevel;
    public int endLevel;
}

public class EnemiesSystem : MonoBehaviour
{  
    [Header("Enemy Main Components")]
    public Rigidbody2D rb2d;
    private DropRateManager dropManager;
    public GameObject playerObj;
    public EnemyStats stats;
    public CharacterStats playerStats;
    public Transform enemyTransform;

    [Header("Enemy Main Stats")] 
    public int enemyLevel = 1;
    public float currentSpeed;
    public int currentHealth;
    public float currentDamage;
    public float currentTiming;

    [Header("Player Detection")]
    protected Vector2 playerTransform;
    protected Vector3 playerVector;
    public float distanceDespawn = 15f;
    Transform player;
    
    [Header("Enemy Knockback")]
    public float knockDuration;
    public float knockForce = 3f;

    public Vector2 moving;
    [HideInInspector]
    public float lastMovHorizon;
    [HideInInspector]
    public float lastMovVertical;
    [HideInInspector]
    AnimateEnemy animate; 
    [HideInInspector]
    public Vector2 lastMovVector;

    bool isMoving = false;
    GameManager gameManager;
    public List<LevelRange> levelRangesEnemy;
    public Text dmgText;

    private FMOD.Studio.EventInstance march;


    public virtual void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dropManager = GetComponent<DropRateManager>();
        playerObj = FindObjectOfType<CharacterStats>().gameObject;
        player = FindObjectOfType<CharacterStats>().transform;
        playerStats = FindObjectOfType<CharacterStats>();

        playerTransform = player.transform.position;
        playerVector = playerObj.transform.position;
        enemyTransform = GetComponent<Transform>(); 
        animate = GetComponent<AnimateEnemy>();

        march = FMODUnity.RuntimeManager.CreateInstance("event:/New Project/Enemy/EnemyIdle");

        OnSpawn();
    }

   public virtual void FixedUpdate()
   {
        if(knockDuration <= 0f)
        {
            EnemyMove();
        }
        else
        {
            Vector2 direction = (playerObj.transform.position - transform.position).normalized;
            rb2d.velocity = -(direction * knockForce);

            knockDuration -= Time.deltaTime; 
        }
        
   }

    public virtual void Update()
    {
        if (Vector2.Distance(transform.position, playerTransform) > distanceDespawn)
        {
            //ReturnTheEnemy();
        }

        //march.setParameterByName("Player-EnemyDistance", Vector2.Distance(transform.position, playerTransform)); 

        if(Time.timeScale==0f)
        {
            march.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); 
        }


    }

    internal void TakeDmg(int v)
    {
        throw new NotImplementedException();
    }

    public virtual void EnemyMove()
    {       
         Vector2 direction = (playerObj.transform.position - transform.position).normalized;
         rb2d.velocity = direction * currentSpeed;

        if(direction.x !=0)
        {
            lastMovHorizon = direction.x;
            moving.x = direction.x; 
        }

        if(direction.y !=0)
        {
            lastMovVertical = direction.y;
            moving.y = direction.y; 
        }
    }

    void ReturnTheEnemy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        //transform.position = player.position + es.points[Random.Range(0, es.points.Count)].position; 
    }

    public virtual void OnSpawn()
    {
        isMoving = true; 
        if(isMoving)
        {
            //march.start(); 
        }
        CalculateStats();
    }

    void CalculateStats()
    {
        enemyLevel      = playerStats.level;
        currentHealth   = stats.EnemyHP + enemyLevel * stats.HealthIncreaseByLevel;
        currentDamage   = stats.EnemyDmg + enemyLevel * stats.DamageIncreaseByLevel;
        currentSpeed    = stats.EnemySpeed + enemyLevel * stats.SpeedIncreseByLevel;
    }   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == playerObj)
        {
            EnemyAttack();
        }
    }
    public virtual void EnemyAttack()
    {
        if(playerObj.GetComponent<CharacterStats>().invincible == false)
        {
            float dmgDealt = currentDamage - playerStats.CurrentArmor;
            playerStats.CurrentHealth -= dmgDealt;
            playerStats.DmgTaken(Mathf.FloorToInt(dmgDealt));
            playerStats.HealthCheck();
        }

        if (playerObj.GetComponent<CharacterStats>().invincible == true)
        {

        }

        if (playerObj.GetComponent<CharacterStats>().CurrentHealth <= 0)
        {
            playerObj.GetComponent<CharacterStats>().Death();
        }
    }

    public virtual void TakeDmg(int dmg, /*Vector2 dmgSource,*/ bool crit, float knockForce = 5f, float duration = 1f)
    {
        currentHealth -= dmg;
        GameManager.GenerateFloatingText(Mathf.FloorToInt(dmg).ToString(), transform, 1f, .75f, crit, false, false);

        if(currentHealth <= 0)
        {
            dropManager.TryDrop();
            Die();
        }
    } 

    public void Die()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Enemy/EnemyKill", transform.position);
        EnemySpawner us = FindObjectOfType<EnemySpawner>();
        us.EnemyKill();
        Destroy(gameObject);
    }

    public void KnockBack(Vector2 knockback, float duration)
    {
        if(duration > 0) return; 

        //knockVelocity = knockback; 
        knockDuration = duration;         
    }
    public void OnDestroy()
    {
        
    }
}

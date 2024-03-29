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

    public List<LevelRange> levelRangesEnemy;

    public Text dmgText; 

    public Rigidbody2D rb2d;
    private DropRateManager dropManager;
    public GameObject playerObj;
    public EnemyStats stats;
    public CharacterStats playerStats; 

    public float currentSpeed;
    public int currentHealth;
    public float currentDamage;
    public float currentTiming;

    GameManager gameManager; 

    public float distanceDespawn = 15f;
    Transform player;

    protected Vector2 playerTransform;
    protected Vector3 playerVector; 

    public int enemyLevel = 1;


    public virtual void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dropManager = GetComponent<DropRateManager>();
        playerObj = FindObjectOfType<CharacterStats>().gameObject;
        player = FindObjectOfType<CharacterStats>().transform;
        playerStats = FindObjectOfType<CharacterStats>();

        playerTransform = player.transform.position;
        playerVector = playerObj.transform.position;


        OnSpawn();
    }



    public virtual void FixedUpdate()
    {
        EnemyMove();
    }

    public virtual void Update()
    {
        if (Vector2.Distance(transform.position, playerTransform) > distanceDespawn)
        {
            ReturnTheEnemy();
        }
    }

    internal void TakeDmg(int v)
    {
        throw new NotImplementedException();
    }

    public virtual void EnemyMove()
    {
        Vector2 direction = (playerVector - transform.position).normalized;
        rb2d.velocity = direction * currentSpeed;
    }

    void ReturnTheEnemy()
    {

    }

    public virtual void OnSpawn()
    {
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
            float dmgDealt = currentDamage - playerStats.currentArmor;
            playerStats.currentNewHP -= dmgDealt;
            playerStats.DmgTaken(Mathf.FloorToInt(dmgDealt));
            playerStats.HealthCheck();
        }

        if (playerObj.GetComponent<CharacterStats>().invincible == true)
        {

        }

        if (playerObj.GetComponent<CharacterStats>().currentNewHP <= 0)
        {
            playerObj.GetComponent<CharacterStats>().Death();
        }
    }

    public virtual void TakeDmg(int dmg, bool crit)
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
        Destroy(gameObject);
    }

    /*public void OnDestroy()
    {
        EnemySpawner us = FindObjectOfType<EnemySpawner>();
        us.EnemyKill();
    }*/
}

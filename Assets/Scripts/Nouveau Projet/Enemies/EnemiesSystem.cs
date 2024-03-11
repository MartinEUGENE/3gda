using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelRange
{
    public int startingLevel;
    public int endLevel;
}

public class EnemiesSystem : MonoBehaviour
{    

    public List<LevelRange> levelRangesEnemy;


    private Rigidbody2D rb2d;
    private DropRateManager dropManager;
    GameObject playerObj;
    public EnemyStats stats;
    CharacterStats playerStats; 

    public float currentSpeed;
    public int currentHealth;
    public float currentDamage;

    public float distanceDespawn = 15f;
    Transform player;

    public int enemyLevel = 1; 


    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dropManager = GetComponent<DropRateManager>();
        playerObj = FindObjectOfType<CharacterStats>().gameObject;
        player = FindObjectOfType<CharacterStats>().transform;
        playerStats = FindObjectOfType<CharacterStats>();


        OnSpawn();
    }



    public void FixedUpdate()
    {
        EnemyMove();
    }

    private void Update()
    {
        //LevelUpCheck();

        if (Vector2.Distance(transform.position, player.position) > distanceDespawn)
        {
            ReturnTheEnemy();
        }
    }

    public virtual void EnemyMove()
    {
        Vector2 direction = (playerObj.transform.position - transform.position).normalized;
        rb2d.velocity = direction * currentSpeed;
    }

    void ReturnTheEnemy()
    {

    }

    void OnSpawn()
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
            float dmgDealt = currentDamage - playerObj.GetComponent<CharacterStats>().currentArmor; 
            playerObj.GetComponent<CharacterStats>().currentNewHP -= dmgDealt;
            playerObj.GetComponent<CharacterStats>().HealthCheck();
            Debug.Log("Attacking the player");
        }

        if (playerObj.GetComponent<CharacterStats>().invincible == true)
        {
            Debug.Log("Look at the moves, FAKER, FAKER, WHAT WAS THAT ???");
        }

            if (playerObj.GetComponent<CharacterStats>().currentNewHP <= 0)
        {
            playerObj.GetComponent<CharacterStats>().Death();
            Debug.Log("Killing the player");

        }
    }

    public virtual void TakeDmg(int dmg)
    {
        currentHealth -= dmg;
        //Debug.Log(dmg);

        if (dmg > 0)
            GameManager.GenerateFloatingText(Mathf.FloorToInt(dmg).ToString(), transform);

        if(currentHealth <= 0)
        {
            dropManager.TryDrop();
            Die();
        }
    } 

    public void Die()
    {
        Destroy(gameObject);
    }

    /*public void OnDestroy()
    {
        EnemySpawner us = FindObjectOfType<EnemySpawner>();
        us.EnemyKill();
    }*/
}

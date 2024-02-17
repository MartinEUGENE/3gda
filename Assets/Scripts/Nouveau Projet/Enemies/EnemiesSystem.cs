using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSystem : MonoBehaviour
{


    [System.Serializable]
    public class LevelRange
    {
        public int startingLevel;
        public int endLevel;
    }

    public List<LevelRange> levelRangesEnemy;


    private Rigidbody2D rb2d;
    GameObject playerObj;
    public EnemyStats stats;
    CharacterStats playerStats; 

    public float currentSpeed;
    public int currentHealth;
    public int currentDamage;

    public float distanceDespawn = 15f;
    Transform player;

    public int enemyLevel = 1; 


    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerObj = FindObjectOfType<CharacterStats>().gameObject;
        player = FindObjectOfType<CharacterStats>().transform;
        playerStats = FindObjectOfType<CharacterStats>();


        currentHealth = stats.EnemyHP;
        currentDamage = stats.EnemyDmg;
        currentSpeed = stats.EnemySpeed;
    }



    public void FixedUpdate()
    {
        EnemyMove();
    }

    private void Update()
    {
        LevelUpCheck();

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
    public void LevelUpCheck()
    {
        if (playerStats.level > enemyLevel)
        {
            currentDamage += 5; 
            currentSpeed *= 1.05f;
            currentHealth += 3;

            enemyLevel++;
            /*foreach (LevelRange range in levelRangesEnemy)
            {
                //experienceCapIncrease = range.expCapIncrease;
                break;
            }
            experienceCap += experienceCapIncrease;*/
        }
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
        playerObj.GetComponent<CharacterStats>().currentNewHP -=  currentDamage; 

        if(playerObj.GetComponent<CharacterStats>().currentNewHP <= 0)
        {
            playerObj.GetComponent<CharacterStats>().Death();
            Debug.Log("Killing the player");

        }
        //Debug.Log("Attacking the player");
    }

    public virtual void TakeDmg(int dmg)
    {
        currentHealth -= dmg; 

        if(currentHealth <= 0)
        {
            Die();
        }
    } 

    public void Die()
    {
        Destroy(gameObject);
    }

    public void OnDestroy()
    {
        EnemySpawner us = FindObjectOfType<EnemySpawner>();
        us.EnemyKill();
    }
}

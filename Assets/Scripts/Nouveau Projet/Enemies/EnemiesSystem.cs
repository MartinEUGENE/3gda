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
    CharacterStats playerStats; 

    public float currentSpeed;
    public int currentHealth;
    public float currentDamage;

    GameManager gameManager; 

    public float distanceDespawn = 15f;
    Transform player;

    public int enemyLevel = 1;


    public virtual void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dropManager = GetComponent<DropRateManager>();
        playerObj = FindObjectOfType<CharacterStats>().gameObject;
        player = FindObjectOfType<CharacterStats>().transform;
        playerStats = FindObjectOfType<CharacterStats>();


        OnSpawn();
    }



    public virtual void FixedUpdate()
    {
        EnemyMove();
    }

    public virtual void Update()
    {
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
        GameManager.GenerateFloatingText(Mathf.FloorToInt(dmg).ToString(), transform);
        Debug.Log(dmg);


        if(currentHealth <= 0)
        {
            dropManager.TryDrop();
            Die();
        }
    } 

    public void Die()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Enemy/EnemyKill", GetComponent<Transform>().position);
        Destroy(gameObject);
    }

    void DmgTxt(int dmg)
    {
        dmgText.enabled = true;

        dmg = 0;
        dmgText.text = string.Format("00", dmg);
    }


    /*public void OnDestroy()
    {
        EnemySpawner us = FindObjectOfType<EnemySpawner>();
        us.EnemyKill();
    }*/
}

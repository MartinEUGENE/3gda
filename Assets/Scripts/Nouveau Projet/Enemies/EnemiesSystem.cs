using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSystem : MonoBehaviour
{
    private Rigidbody rb2d;
    GameObject playerObj;
    public EnemyStats stats;

    public float currentSpeed;
    public int currentHealth;
    public int currentDamage;

    public float distanceDespawn = 15f;
    Transform player; 

    public void Awake()
    {
        rb2d = GetComponent<Rigidbody>();
        playerObj = FindObjectOfType<CharacterStats>().gameObject;
        player = FindObjectOfType<CharacterStats>().transform;

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
        if(Vector3.Distance(transform.position, player.position) > distanceDespawn)
        {
            ReturnTheEnemy();
        }
    }

    public virtual void EnemyMove()
    {
        Vector3 direction = (playerObj.transform.position - transform.position).normalized;
        rb2d.velocity = direction * currentSpeed;
    }

    void ReturnTheEnemy()
    {

    }

    public void OnTriggerEnter(Collider collision)
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

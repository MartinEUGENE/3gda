using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSystem : MonoBehaviour
{
    [SerializeField] public Transform player;   
    private Rigidbody rb2d;
    [SerializeField] public GameObject playerObj;
    public EnemyStats stats;

    public float currentSpeed;
    public int currentHealth;
    public int currentDamage;

    public void Awake()
    {
        rb2d = GetComponent<Rigidbody>();
        playerObj = player.gameObject;

        currentHealth = stats.EnemyHP;
        currentDamage = stats.EnemyDmg;
        currentSpeed = stats.EnemySpeed;
    }
    public void FixedUpdate()
    {
        EnemyMove();
    }

    public virtual void EnemyMove()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        rb2d.velocity = direction * currentSpeed;
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
        Debug.Log("Attacking the player");
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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSystem : MonoBehaviour
{
    [SerializeField] public Transform player;   
    private Rigidbody rb2d;
    [SerializeField] public GameObject playerObj;
    public EnemyStats stats;

    public void Awake()
    {
        rb2d = GetComponent<Rigidbody>();
        playerObj = player.gameObject; 
    }
    public void FixedUpdate()
    {
        EnemyMove();
    }

    public virtual void EnemyMove()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        rb2d.velocity = direction * stats.enemySpeed;
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
        playerObj.GetComponent<CharacterStats>().currentHP -= stats.enemyDmg; 

        if(playerObj.GetComponent<CharacterStats>().currentHP < 1)
        {
            playerObj.GetComponent<CharacterStats>().Death();
        }
        Debug.Log("Attacking the player");
    }

    public virtual void TakeDmg(int dmg)
    {
        stats.enemyHP -= dmg; 

        if(stats.enemyHP < 1)
        {
            Destroy(gameObject);
        }
    } 

}

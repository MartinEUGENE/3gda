using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSystem : MonoBehaviour
{
    [SerializeField] public Transform player; 
    [SerializeField] public float enemySpeed = 8f;


    [SerializeField] public int enemyHP = 15; 

    private Rigidbody2D rb2d;
    GameObject playerObj; 

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerObj = player.gameObject; 
    }
    public void FixedUpdate()
    {
        EnemyMove();
    }

    public virtual void EnemyMove()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        rb2d.velocity = direction * enemySpeed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == playerObj)
        {
            EnemyAttack();
        }
    }

    public virtual void EnemyAttack()
    {
        Debug.Log("Attacking the player");
    }

    public virtual void TakeDmg(int dmg)
    {
        enemyHP -= dmg; 

        if(enemyHP < 1)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameObject player;
    public TurretEnemy stats; 

    public float bullSpeed; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<CharacterStats>().gameObject;
        Vector3 dir = (player.transform.position - transform.position).normalized;

        stats = GetComponent<TurretEnemy>();

        rb.velocity = new Vector2(dir.x, dir.y) * bullSpeed; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            stats.EnemyAttack();
        }
    }

}

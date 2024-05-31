using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameObject player;
    public TurretEnemy stats; 

    public float bullSpeed;
    public float lifeSpain = 30f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = FindObjectOfType<TurretEnemy>(); 
        player = FindObjectOfType<CharacterStats>().gameObject;
        Vector3 dir = (player.transform.position - transform.position).normalized;

        rb.velocity = new Vector2(dir.x, dir.y) * bullSpeed;
        float rot = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, 270 + rot); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            stats.EnemyAttack();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        lifeSpain -= Time.fixedDeltaTime;
        if(lifeSpain <= 0f)
        {
            Destroy(gameObject);
        }
    }


}

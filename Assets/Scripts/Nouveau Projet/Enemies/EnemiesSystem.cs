using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSystem : MonoBehaviour
{
    [SerializeField] public Transform player; 
    [SerializeField] public float enemySpeed = 8f;

    private Rigidbody rb;
    GameObject playerObj; 

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerObj = player.gameObject; 
    }
    public void FixedUpdate()
    {
        EnemyMove();
    }

    public virtual void EnemyMove()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * enemySpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == playerObj)
        {
            EnemyAttack();
        }
    }


    public virtual void EnemyAttack()
    {
        Debug.Log("Attacking the player");
    }
}

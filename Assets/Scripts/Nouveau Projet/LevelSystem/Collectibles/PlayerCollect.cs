using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    CharacterStats player;
    CircleCollider2D circlePlayer;

    public float pullForce;
  


    void Start()
    {
        player = FindObjectOfType<CharacterStats>();
        circlePlayer = GetComponent<CircleCollider2D>();
    }


    void Update()
    {
        circlePlayer.radius = player.currentpickUp; 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out ICollectibles collect))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 ForceDir = (transform.position - collision.transform.position).normalized;
            rb.AddForce(ForceDir * pullForce);
            collect.Collect();
        }
    }
}

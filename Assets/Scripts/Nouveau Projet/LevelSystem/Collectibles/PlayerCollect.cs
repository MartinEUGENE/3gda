using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    CharacterStats player;
    CircleCollider2D detect;

    public float pullForce;

    void Start()
    {
        player = GetComponentInParent<CharacterStats>();
    }

    public void SetDetection(float rayon)
    {
        if(!detect)
        {
            detect = GetComponent<CircleCollider2D>();
        }

        detect.radius = rayon;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PickUp pick))
        {
            pick.Collect(player, pullForce, .8f); 
        }
    }
}

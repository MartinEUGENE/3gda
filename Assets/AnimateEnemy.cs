using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateEnemy : MonoBehaviour
{
    Animator animate;
    EnemiesSystem ch;
    SpriteRenderer sp; 
    
    void Start()
    {
        animate = GetComponent<Animator>();
        ch = GetComponent<EnemiesSystem>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ch.moving.x != 0 || ch.moving.y != 0)
        {
            SpriteFlipper();
        }
    }

    void SpriteFlipper()
    {
        if (ch.lastMovHorizon < 0)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }

    }
}

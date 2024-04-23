using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator animate;
    CharactControls ch;
    SpriteRenderer sp; 
    void Start()
    {
        animate = GetComponent<Animator>();
        ch = GetComponent<CharactControls>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ch.moving.x !=0 || ch.moving.y != 0)
        {
            animate.SetBool("Move", true);
            SpriteFlipper();
        }
        else
        {
            animate.SetBool("Move", false);

        }
    }

    void SpriteFlipper()
    {
        if(ch.lastMovHorizon < 0)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false; 
        }

    }
}

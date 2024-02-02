using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWeapon : WeaponSystem
{

    [SerializeField] GameObject rightAttack;
    [SerializeField] GameObject leftAttack;

    [SerializeField] Vector2 attackSize = new Vector2();

    CharactControls player; 

    void Start()
    {
        player = GetComponentInParent<CharactControls>();
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown<0f)
        {
            Shoot();
        }
    }

    public override void Shoot()
    {
        cooldown = weaponReload;

        if(player.lastMovHorizon < 0)
        {
            rightAttack.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightAttack.transform.position, attackSize, 0f);
            ApplyDmg(colliders);
        }

        else
        {
            leftAttack.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftAttack.transform.position, attackSize, 0f); ;
            ApplyDmg(colliders);
        }
    }

    public override void ApplyDmg(Collider2D[] collider)
    {
        for(int i = 0; i < collider.Length; i++ )
        {
            EnemiesSystem E = GetComponent<EnemiesSystem>(); 
            if(E != null)
            {
                collider[i].GetComponent<EnemiesSystem>().TakeDmg(damage);
                Debug.Log(collider[i]);
            }
        }
    }
}

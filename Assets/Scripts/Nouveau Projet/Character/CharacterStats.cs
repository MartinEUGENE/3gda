using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : LevelSystem
{
    [SerializeField] public CharactControls chara;
    //[SerializeField] public FirstWeapon weep;
    [SerializeField] public GameObject player; 

    [Header("Attack Stats")]

    public int attack = 10;
    public float attackHaste = 1;
    public int criticalRate = 10; 
    public int criticalDmg = 100;


    [Header("Health")]
    public int maxHP = 100;
    public int currentHP = 0;

    [Header("Other Stats")]

    public int pickUp = 15;


    void Start()
    {
        experience = 0;
        level = 1;

        currentHP = maxHP;

        //chara.movSpeed = 3f;

        player = GetComponent<GameObject>(); 

    }

    void Update()
    {
        if(experience >= requieredXP)
        {
            LevelUpPlayer(); 
        }
    }


    public override void LevelUpPlayer()
    {

    }

    public void Death()
    {
        if(currentHP < 1)
        {
            chara.enabled = false;
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : LevelSystem
{
    [SerializeField] CharactControls chara;
    [SerializeField] FirstWeapon weep;

    void Start()
    {
        experience = 0;
        level = 1;


        chara = GetComponent<CharactControls>();
        chara.maxHP = 100; 
        chara.movSpeed = 15f;

        weep = GetComponent<FirstWeapon>(); 

    }

    void Update()
    {
        if(experience == 100)
        {
            LevelUpPlayer(); 
        }
    }


    public override void LevelUpPlayer()
    {
        chara.movSpeed += 1f;
        chara.maxHP += 10;
        chara.currentHP = chara.maxHP; 
    }


}

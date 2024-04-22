using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    public PassiveScriptable passiveItem; 
    protected CharacterStats player;

    public int currentLevel = 1;

    void Start()
    {
        player = FindObjectOfType<CharacterStats>();
        ApplyStats();
    }

    protected virtual void ApplyStats()
    {

    }
/*
    protected virtual void Update()
    {
        CheckLevel();
    }

    public void GetALevelUp(PassiveScriptable passive)
    {
        passiveItem = passive; 
    }


    void CheckLevel()
    {
        if(currentLevel != passiveItem.Level)
        {
            currentLevel = passiveItem.Level;
        }
    }*/

}

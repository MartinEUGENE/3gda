using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    public PassiveScriptable passiveItem; 
    protected CharacterStats player;

    void Start()
    {
        player = FindObjectOfType<CharacterStats>();
        ApplyStats();
    }

    protected virtual void ApplyStats()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarItem : PassiveItem
{
    protected override void ApplyStats()
    {
        player.currentCriticalRate *= 1 + passiveItem.Multiplier / 100f ;
        //player.currentAttack *= 1 + (passiveItem.Multiplier + 20f) / 100f; 
    }
}

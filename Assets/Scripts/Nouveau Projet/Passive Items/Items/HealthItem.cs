using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : PassiveItem
{
    protected override void ApplyStats()
    {
        player.CurrentMaxHealth += passiveItem.Multiplier;
        player.HealthCheck(); 

        if (passiveItem.Level == 5)
        {
            player.CurrentAttack += passiveItem.Multiplier/4;
        }
    }

}

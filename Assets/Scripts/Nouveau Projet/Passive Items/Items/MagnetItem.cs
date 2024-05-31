using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : PassiveItem
{
    protected override void ApplyStats()
    {
        player.collect.SetDetection(player.CurrentPickUp += passiveItem.Multiplier) ;

        if (passiveItem.Level == 5)
        {
            player.collect.SetDetection(player.CurrentPickUp = 2) ;
            player.CurrentArmor += 15; 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationItem : PassiveItem
{ 
    protected override void ApplyStats()
    {
        player.currentNewHP += passiveItem.Multiplier;
        player.HealthCheck();

        if (passiveItem.Level == 5)
        {
            player.CurrentAttack += passiveItem.Multiplier / 4;
        }
    }
}

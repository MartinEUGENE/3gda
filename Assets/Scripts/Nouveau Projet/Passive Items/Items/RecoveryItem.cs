using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryItem : PassiveItem
{
    protected override void ApplyStats()
    {
        player.CurrentRecovery += passiveItem.Multiplier;
        
        if (passiveItem.Level == 5)
        {
            player.CurrentCritRate *= passiveItem.Multiplier;
        }
    }
}

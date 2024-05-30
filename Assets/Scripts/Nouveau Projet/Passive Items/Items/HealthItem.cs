using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : PassiveItem
{
    protected override void ApplyStats()
    {
        player.currentMaxHP += passiveItem.Multiplier;
        if (player.CurrentHealth < player.currentMaxHP && passiveItem.Level == 5)
        {
            player.CurrentAttack += passiveItem.Multiplier/2;
        }
    }
}

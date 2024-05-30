using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorItem : PassiveItem
{
    protected override void ApplyStats()
    {
        player.CurrentArmor += Mathf.FloorToInt(passiveItem.Multiplier);

        if (passiveItem.Level == 5)
        {
            player.CurrentPickUp = 2f;
        }
    }
}

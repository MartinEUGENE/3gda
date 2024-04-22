using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrenghtItem : PassiveItem
{
    protected override void ApplyStats()
    {
        player.currentAttack *= Mathf.FloorToInt(1 + passiveItem.Multiplier / 100f);
    }
}


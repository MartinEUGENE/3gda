using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrenghtItem : PassiveItem
{
    protected override void ApplyStats()
    {
        player.CurrentAttack += Mathf.FloorToInt(passiveItem.Multiplier);
    }
}


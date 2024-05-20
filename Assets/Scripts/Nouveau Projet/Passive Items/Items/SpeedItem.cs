using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : PassiveItem
{
    protected override void ApplyStats()
    {
        player.CurrentMovSpeed *= passiveItem.Multiplier; 
    }

}

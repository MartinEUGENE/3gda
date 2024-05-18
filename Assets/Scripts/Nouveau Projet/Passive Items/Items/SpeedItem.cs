using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : PassiveItem
{
    protected override void ApplyStats()
    {
        player.currentSpeed *= passiveItem.Multiplier; 
    }

}

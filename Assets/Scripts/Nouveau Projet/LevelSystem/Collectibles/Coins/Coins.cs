using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : PickUp, ICollectibles
{
    public int goldGranted;
    public void Collect()
    {
        CharacterStats player = FindObjectOfType<CharacterStats>();
        player.IncreaseGold(goldGranted);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPots : PickUp, ICollectibles
{
    public float healing; 

    public void Collect()
    {
        CharacterStats player = FindObjectOfType<CharacterStats>();
        player.Healing(healing);
    }

}

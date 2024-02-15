using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGems : MonoBehaviour, ICollectibles
{
    public int xpGranted;
    public void Collect()
    {
        CharacterStats player = FindObjectOfType<CharacterStats>();
        player.IncreaseExperience(xpGranted);
        Destroy(gameObject);  //ici pour martin : fair une bar UI qui monte a chaque grab
    }    
}

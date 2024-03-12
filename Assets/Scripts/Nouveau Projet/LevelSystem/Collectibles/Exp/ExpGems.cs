using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGems : PickUp, ICollectibles
{
    public int xpGranted;
    public void Collect()
    {
        CharacterStats player = FindObjectOfType<CharacterStats>();
        player.IncreaseExperience(xpGranted);
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.gameObject.CompareTag("Weapon"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Collectibles/Exp/ExpCollect");
            Destroy(gameObject);
        }
    }

}

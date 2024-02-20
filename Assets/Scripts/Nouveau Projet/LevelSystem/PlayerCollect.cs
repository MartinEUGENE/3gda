using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    /*public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICollectibles collect))
        {
        }
    }*/

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out ICollectibles collect))
        {
            collect.Collect();
        }
    }
}

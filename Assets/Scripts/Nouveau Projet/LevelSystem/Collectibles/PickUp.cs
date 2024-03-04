using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.gameObject.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
    }
}

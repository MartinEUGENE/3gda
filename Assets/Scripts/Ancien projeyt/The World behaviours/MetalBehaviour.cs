using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBehaviour : MonoBehaviour

{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object on top has a rigidbody and is tagged as "Player" or "Rock"
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Rock"))
        {
            // Check if the object is directly above the metallic object
            Vector3 offset = collision.contacts[0].point - transform.position;
            if (Mathf.Abs(offset.x) < transform.localScale.x / 2 && Mathf.Abs(offset.z) < transform.localScale.z / 2)
            {
                // Make the object a child of the metallic object
                collision.collider.transform.parent = transform;
            }
        }
    }

    //private void OnCollisionExit(Collision collision)
   // {
        // Remove the object as a child when it leaves the collision area
       // collision.collider.transform.parent = null;
   // }
}




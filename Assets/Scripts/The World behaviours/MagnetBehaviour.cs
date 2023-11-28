using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBehaviour : BroColor
{    
    public float raycastDistance = 10f;
    public float castRadius = 1.0f;
    public float moveSpeed = 10f;
    public bool attract = false;

    private void Start()
    {
        GetComponent<Rigidbody>();

    }



    void Update()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, castRadius, transform.forward, raycastDistance);

        // Draw the cast for visualization
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.blue);


        // Check each object hit by the raycast
        foreach (RaycastHit hit in hits)
        {
            // Check if the object has the tag "metal"
            if (hit.collider.CompareTag("Metal"))
            {
                
                if(attract == true) 
                {
                    Debug.Log("Metal object hit ");
                    MoveMetalObject(hit.collider.gameObject);
                }
                // Do something with the metal object, e.g., apply a special effect
            }
        }

    }

    protected override void CustomActivation()
    {

        //count += 1f; 
        Debug.Log("magnet is gay, good for them");
        rb.useGravity = true;
        rb.isKinematic = false;

        attract = true;
        //Debug.Log("colo ");
        //rb.useGravity = true;
        //rb.isKinematic = false;

    }

    protected override void CustomDeactivation()
    {


        attract = false;
        Debug.Log("NO colo ");
        //rb.useGravity = false;
        //rb.isKinematic = true;
    }

    void MoveMetalObject(GameObject metalObject)
    {
        // Calculate the direction from the metal object to the object with this script
        Vector3 direction = (transform.position - metalObject.transform.position).normalized;

        // Calculate the distance to the magnet
        float distanceToMagnet = Vector3.Distance(transform.position, metalObject.transform.position);

        // Move the metal object towards the object with this script with a force proportional to the distance
        metalObject.GetComponent<Rigidbody>().AddForce(direction * moveSpeed * distanceToMagnet);
    }


}

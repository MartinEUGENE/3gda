using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBehaviour : BroColor
{
    //public float raycastDistance = 10f;
    //public float castRadius = 1.0f;
    public float magnetSpeed = .01f;
    //public bool attract = false;

    [SerializeField] List<GameObject> metal;
    [SerializeField] Renderer magnetRenderer;


    private void Start()
    {
        magnetRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isActive == true)
        {
            MoveMetalObject(metal);
        }
    }

    public override void CustomActivation()
    {
        isActive = true;
        magnetRenderer.material.color = Color.black;
        Debug.Log("magnet");
    }

    public override void CustomDeactivation()
    {
        magnetRenderer.material.color = Color.white;
        isActive = false;
        Debug.Log("NO colo");
    }

    void MoveMetalObject(List<GameObject> magnetized)
    {
        foreach(GameObject magnetizedObj in magnetized)
        {
            if (magnetizedObj.GetComponent<BroColor>().isActive == true)
            {
                Vector3 direction = (transform.position - magnetizedObj.transform.position).normalized;

                // Calculate the distance to the magnet
                float distanceToMagnet = Vector3.Distance(transform.position, magnetizedObj.transform.position);
                if(distanceToMagnet <= 15f)
                {
                    // Move the metal object towards the object with this script with a force proportional to the distance
                    magnetizedObj.GetComponent<Rigidbody>().AddForce(direction * magnetSpeed /* distanceToMagnet*/);
                }

            }
        }
    }


}



/*

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
            }*/

// Calculate the direction from the metal object to the object with this script
/* Vector3 direction = (transform.position - metalObject.transform.position).normalized;

// Calculate the distance to the magnet
 float distanceToMagnet = Vector3.Distance(transform.position, metalObject.transform.position);

// Move the metal object towards the object with this script with a force proportional to the distance
metalObject.GetComponent<Rigidbody>().AddForce(direction * moveSpeed * distanceToMagnet);*/
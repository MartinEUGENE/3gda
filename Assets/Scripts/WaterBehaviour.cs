using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : BroColor
{
    public float conveyorForce = 10.0f;
    public bool active = false;
    
    /* private void OnCollisionEnter(Collision collision)
     {
         Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
         if (rb != null || active == true)
         {
             //Debug.Log("Object Name: ");
             rb.AddForce(transform.forward * conveyorForce, ForceMode.Acceleration);
         }
     }*/

    protected override void CustomActivation()
    {
        active = true;
    }

    protected override void CustomDeactivation()
    {
        active = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(active == true)
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * conveyorForce, ForceMode.Acceleration);
            }
        }


    }
}

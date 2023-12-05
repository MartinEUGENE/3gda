using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : BroColor
{
    private SphereCollider sp;
    public float maxSpeed = 2.5f; 

    void Start()
    {
        sp = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>(); 
    }


    private void FixedUpdate()
    {
         //Vector3 regularSpeed = new Vector3( 0f, maxSpeed, 0f) ;

        if(isActive == true && !gameObject.CompareTag("Fog") && rb.velocity.y <= maxSpeed)
        {
            rb.AddForce(transform.up * 0.25f, ForceMode.Force); //Faire en sorte à ce que ce soit controlé par des tags aussi
            Debug.Log(rb.velocity.y);
        }
    }


    public override void CustomActivation()
    {
        Debug.Log("IT IS PAINTED");
        sp.isTrigger = true;
        rb.isKinematic = false; 
        isActive = true;
    }

    public override void CustomDeactivation()
    {
        isActive = false;

        Debug.Log("DO NOT paint");
        sp.isTrigger = false;
        rb.isKinematic = true; 
    }
}

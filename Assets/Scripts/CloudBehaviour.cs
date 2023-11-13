using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : BroColor
{
    private SphereCollider sp;

    void Start()
    {
        sp = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>(); 
    }


    private void FixedUpdate()
    {
        if(isActive == true && !gameObject.CompareTag("Fog"))
        {
            rb.AddForce(transform.up * 0.2f, ForceMode.Force); //Faire en sorte à ce que ce soit controlé par des tags aussi
        }
    }


    protected override void CustomActivation()
    {
        Debug.Log("IT IS PAINTED");
        sp.isTrigger = true;
        rb.isKinematic = false; 
    }

    protected override void CustomDeactivation()
    {
        Debug.Log("DO NOT paint");
        sp.isTrigger = false;
        rb.isKinematic = true; 
    }
}

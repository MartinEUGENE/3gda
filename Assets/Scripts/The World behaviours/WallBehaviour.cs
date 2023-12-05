using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : BroColor 
{
    Collider wally;
    MeshRenderer rendo; 

    void Start()
    {
        wally = GetComponent<Collider>();
        wally.isTrigger = false;

        rendo = GetComponent<MeshRenderer>();
    }

    public override void CustomActivation()
    {
        isActive = true;       
    }

    public override void CustomDeactivation()
    {
        isActive = false; 
        wally.isTrigger = false;

        rendo.enabled = true; 
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(isActive && collision.collider.CompareTag("Rock"))
        {
            wally.isTrigger = true;
            rendo.enabled = false; 
        }
    }

}

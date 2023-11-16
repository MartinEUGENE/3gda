using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : BroColor 
{
    Collider wally; 

    void Start()
    {
        wally = GetComponent<Collider>();
        wally.isTrigger = false;
    }

    protected override void CustomActivation()
    {
        isActive = true;       
    }

    protected override void CustomDeactivation()
    {
        isActive = false; 
        wally.isTrigger = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(isActive && collision.collider.CompareTag("Rock"))
        {
            wally.isTrigger = true; 
        }
    }

}

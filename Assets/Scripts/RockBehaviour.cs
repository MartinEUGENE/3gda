using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : BroColor
{

    private void Start()
    {
        GetComponent<Rigidbody>(); 
    }
    protected override void CustomActivation()
    {
        Debug.Log("rock is painted");
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    protected override void CustomDeactivation()
    {
        Debug.Log("rock is clean now");
        rb.useGravity = false;
        rb.isKinematic = true;
    }
}

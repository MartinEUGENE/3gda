using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetBehaviour : BroColor
{

    private void Start()
    {
        GetComponent<Rigidbody>();

    }

    protected override void CustomActivation()
    {
        //count += 1f; 
        Debug.Log("magnet is gay, good for them");
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    protected override void CustomDeactivation()
    {
        Debug.Log("magnet is still gay");
        rb.useGravity = false;
        rb.isKinematic = true;
       
    }

}

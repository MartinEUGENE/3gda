using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : BroColor
{
    public ColorControl colorCont;

    protected override void CustomActivation()
    {
        Debug.Log("rock activation");
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    protected override void CustomDeactivation()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
    }
}

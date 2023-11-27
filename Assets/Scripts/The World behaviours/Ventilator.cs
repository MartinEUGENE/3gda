using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilator : BroColor
{
    public GameObject Wind;
    private WindBehav wond;


    private void Start()
    {
        wond = GetComponent<WindBehav>();
    }

    protected override void CustomActivation()
    {
        WindBehav clony = Instantiate(wond, transform.position + transform.up*2f, transform.rotation);
    }

    protected override void CustomDeactivation()
    {
        wond.isActive = false; 
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilator : BroColor
{
    public GameObject Wind;

    //private WindBehav wond;


    private void Start()
    {
        //wond = GetComponent<WindBehav>();
       // Wind = GetComponent<GameObject>();
    }

    protected override void CustomActivation()
    {
        GameObject clony = Instantiate(Wind, transform.position + transform.up*1f, transform.rotation);
    }

    protected override void CustomDeactivation()
    {
       // wond.isActive = false; 
    }

}

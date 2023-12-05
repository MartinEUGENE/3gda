using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilator : BroColor
{
    public GameObject Wind;
    GameObject storeWind;
        

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //wond = GetComponent<WindBehav>();
       // Wind = GetComponent<GameObject>();
    }

    public override void CustomActivation()
    {
        isActive = true;

        GameObject clony = Instantiate(Wind, transform.position + transform.up*1f, transform.rotation);
        storeWind = clony;
    }

    public override void CustomDeactivation()
    {
        Destroy(storeWind);
        isActive = false;

    }

}

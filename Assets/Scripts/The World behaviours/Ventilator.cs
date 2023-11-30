using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilator : BroColor
{
    public GameObject Wind;
    GameObject storeWind; 

    //private WindBehav wond;


    private void Start()
    {
        //wond = GetComponent<WindBehav>();
       // Wind = GetComponent<GameObject>();
    }

    protected override void CustomActivation()
    {
        GameObject clony = Instantiate(Wind, transform.position + transform.up*1f, transform.rotation);
        storeWind = clony;
    }

    protected override void CustomDeactivation()
    {
        Destroy(storeWind);
    }

}

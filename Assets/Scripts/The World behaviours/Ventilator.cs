using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilator : BroColor
{
    public GameObject Wind;
    //GameObject storeWind;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Wind.SetActive(false);
    }

    public override void CustomActivation()
    {
        isActive = true;
        Wind.SetActive(true);
    }

    public override void CustomDeactivation()
    {
        Wind.SetActive(false);  
        isActive = false;
    }

}

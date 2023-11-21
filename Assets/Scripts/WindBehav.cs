using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBehav : BroColor
{
    public float windForce = 25f;
    public float smallForce = 15f;
    public float small = 5f;



    private Collider windo; 
    void Start()
    {
        windo = GetComponent<Collider>();
        windo.isTrigger = true; 
    }

    protected override void CustomActivation()
    {
        isActive = true;
       // windo.isTrigger = true;
    }

    protected override void CustomDeactivation()
    {
        isActive = false;
        //windo.isTrigger = false;

    }

    private void OnTriggerStay(Collider other)
    {
        if(isActive == true && other.CompareTag("Cloud"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * windForce, ForceMode.Acceleration);
        }

        if (isActive == true && other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * smallForce, ForceMode.Force);
            Debug.Log("Yo");
        }

        if (isActive == true && !other.CompareTag("Cloud"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * small, ForceMode.Force);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : BroColor
{
    public float conveyorForce = 10.0f;
    public bool active = false;
    private BoxCollider woter;
    private FMOD.Studio.EventInstance wa;


    private void Start()
    {
        woter = GetComponent<BoxCollider>();
        woter.isTrigger = false;
        wa = FMODUnity.RuntimeManager.CreateInstance("event:/Mechanics/Water");
    }

    /* private void OnCollisionEnter(Collision collision)
     {
         Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
         if (rb != null || active == true)
         {
             //Debug.Log("Object Name: ");
             rb.AddForce(transform.forward * conveyorForce, ForceMode.Acceleration);
         }
     }*/

    protected override void CustomActivation()
    {
        active = true;
        woter.isTrigger = true;
        wa.start();
        wa.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    protected override void CustomDeactivation()
    {
        active = false;
        woter.isTrigger = false;
        wa.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }


    private void OnTriggerStay(Collider other)
    {
        if(active == true)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Rigidbody>().AddForce(transform.forward * 30f);
            }

            if (rb != null)
            {
                other.GetComponent<Rigidbody>().AddForce(transform.forward * 10f);
            }
        }
    }
}

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
        //wa = FMODUnity.RuntimeManager.CreateInstance("event:/Mechanics/Water");
    }

     /*private void OnCollisionEnter(Collision collision)
     {
         Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
         if (rb != null && active == true && !collision.gameObject.CompareTag("Player"))
         {
             //Debug.Log("Object Name: ");
             rb.AddForce(transform.forward * conveyorForce, ForceMode.Acceleration);
         }
     }*/

    protected override void CustomActivation()
    {
        active = true;
        woter.isTrigger = true;
        //wa.start();
        //wa.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    protected override void CustomDeactivation()
    {
        active = false;
        woter.isTrigger = false;
        //wa.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    protected override void PlaySound()
    {
        if (isActive && count <= 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/BGM/BGM");
            //B.start();
            count = 1;
            B.setParameterByName("BGM", count);
        }

        /*if (!isActive && count >= 0)
        {
            count--;
            B.setParameterByName("BGM", count);
        }*/
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (active == true)
        {

            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * conveyorForce, ForceMode.Acceleration);
            }
        }

    }*/

    private void OnTriggerStay(Collider other)
    {
        if (active == true && other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * 12.5f, ForceMode.Force);
        }

        if(active == true && !other.CompareTag("Player") && !other.CompareTag("Ground"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Acceleration);

        }
    }
}


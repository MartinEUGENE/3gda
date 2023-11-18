using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : BroColor
{
    public float conveyorForce = 10.0f;
    public bool active = false;
    private BoxCollider woter;
    public FMOD.Studio.EventInstance wa;


    private void Start()
    {
        woter = GetComponent<BoxCollider>();
        woter.isTrigger = false;
        wa = FMODUnity.RuntimeManager.CreateInstance("event:/Mechanics/Water");

        wa.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
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
       /* paint.start();
        paint.setParameterByNameWithLabel("Activation", "Active");*/
        wa.start();
        
    }

    protected override void CustomDeactivation()
    {
        active = false;
        woter.isTrigger = false;
       /* paint.start();
        paint.setParameterByNameWithLabel("Activation", "Active");*/
        wa.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    
   /* private void OnTriggerEnter(Collider other)
    {
        if (active == true && other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * conveyorForce);
        }
            
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (active == true && other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * 12.5f, ForceMode.Force);
        }

<<<<<<< HEAD
       /* if(active == true && !other.CompareTag("Player") && !other.CompareTag("Ground"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Acceleration);

        }*/

        if (active == true && other.CompareTag("Rock") && !other.CompareTag("Cloud") && !other.CompareTag("Fog") && !other.CompareTag("Ground"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * 15f, ForceMode.Acceleration);

=======
        if(active == true && !other.CompareTag("Player") && !other.CompareTag("Ground") && !other.CompareTag("Cloud"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Acceleration);
>>>>>>> SoundDesign
        }

    }
}


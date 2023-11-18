using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : BroColor
{
    public float conveyorForce = 15.0f;     //Pour les cailloux
    public float smallForce = 12.5f;      //Pour le joueur


    private BoxCollider woter;
    public FMOD.Studio.EventInstance wa;
    public FMOD.Studio.EventInstance so;

    private void Start()
    {
        woter = GetComponent<BoxCollider>();
        woter.isTrigger = false;
        wa = FMODUnity.RuntimeManager.CreateInstance("event:/Mechanics/Water");
        so = FMODUnity.RuntimeManager.CreateInstance("event:/WaterIn"); 

        wa.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }


    protected override void CustomActivation()
    {
        isActive = true; 
        woter.isTrigger = true;       
        wa.start();        
    }

    protected override void CustomDeactivation()
    {
        isActive = false; 
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

    private void OnTriggerEnter(Collider other)
    {
        bool inside = true;

        if (isActive && inside && other.CompareTag("Player"))
        {
            inside = false;
            so.start();
            Debug.Log("Ga");
        }


        if(isActive && inside && other.CompareTag("Rock"))
        {
            inside = false;
            //so.start();
            Debug.Log("gruuuuuuuuuuuuuuuuu");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isActive == true && other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * smallForce, ForceMode.Force);
        }

        if (isActive == true && other.CompareTag("Rock") && !other.CompareTag("Cloud") && !other.CompareTag("Fog") && !other.CompareTag("Ground"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * conveyorForce, ForceMode.Acceleration);
        }

    }
}


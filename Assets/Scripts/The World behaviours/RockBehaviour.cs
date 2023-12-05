using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : BroColor
{
    private FMOD.Studio.EventInstance rocking;
    private FMOD.Studio.EventInstance fally;

    public int count = 0;


    private void Start()
    {
        GetComponent<Rigidbody>();
        rocking = FMODUnity.RuntimeManager.CreateInstance("event:/Environement/Rock");
        fally = FMODUnity.RuntimeManager.CreateInstance("event:/InteractiveEnvironement/Rock_Fall");

        rocking.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

  
    public override void CustomActivation()
    {
        count += 1; 
        Debug.Log("rock is painted");

        isActive = true;

        rb.useGravity = true;
        rb.isKinematic = false;

        rocking.start();
        rocking.setParameterByName("RockParameter", count);

        if(rb.mass >= 50)
        {
            rb.AddForce(transform.up * -1000f, ForceMode.Acceleration);
        }     
    }

    public override void CustomDeactivation()
    {
        Debug.Log("rock is clean now");
        isActive = false;
        rb.useGravity = false;
        rb.isKinematic = true;
        rocking.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);        
    }

    private void OnTriggerEnter(Collider other)
    {
        bool walter = true; 

        if(walter && isActive && other.CompareTag("Wall"))
        {
            Debug.Log("The wall was breached"); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool afall = false;

        if(afall == false && isActive == true)
        {
            fally.start();
            afall = true;
        }
    }
}

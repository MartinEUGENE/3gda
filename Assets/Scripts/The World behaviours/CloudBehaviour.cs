using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : BroColor
{
    private Collider sp;

    public float maxSpeed;
    public Vector3 nuage; 

    public FMOD.Studio.EventInstance Cloud;
    public FMOD.Studio.EventInstance Fog;

    private FMOD.Studio.EventInstance inactEvent;


    void Start()
    {
        sp = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        //obj = GetComponent<GameObject>();


        Cloud = FMODUnity.RuntimeManager.CreateInstance("event:/Environement/Cloud"); 
        Fog = FMODUnity.RuntimeManager.CreateInstance("event:/Environement/Fog");

        rb.isKinematic = true; 
    }


    private void FixedUpdate()
    {
         //Vector3 regularSpeed = new Vector3( 0f, maxSpeed, 0f) ;

        if(isActive == true && !gameObject.CompareTag("Fog"))
        {
            rb.AddForce(nuage * maxSpeed); //Faire en sorte à ce que ce soit controlé par des tags aussi
        }
    }


    public override void CustomActivation()
    {
        Debug.Log("IT IS PAINTED");
        sp.isTrigger = true;
        rb.isKinematic = false; 
        isActive = true;

        if(gameObject.CompareTag("Cloud"))
        {

        }

        if (gameObject.CompareTag("Fog"))
        {

        }


    }

    public override void CustomDeactivation()
    {
        isActive = false;

        Debug.Log("DO NOT paint");
        sp.isTrigger = false;
        rb.isKinematic = true; 
    }
}

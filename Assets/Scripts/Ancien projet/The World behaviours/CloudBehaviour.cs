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
    public FMOD.Studio.EventInstance inactiveFog;
    public FMOD.Studio.EventInstance inactiveCloud;



    void Start()
    {
        sp = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        //obj = GetComponent<GameObject>();

        Cloud = FMODUnity.RuntimeManager.CreateInstance("event:/Environement/Cloud"); 
        Fog = FMODUnity.RuntimeManager.CreateInstance("event:/Environement/Fog");
        inactiveCloud = FMODUnity.RuntimeManager.CreateInstance("event:/InactiveEnvironement/Inactive_Cloud");
        inactiveFog = FMODUnity.RuntimeManager.CreateInstance("event:/InactiveEnvironement/Inactive_Fog");

        rb.isKinematic = true;

        if(gameObject.CompareTag("Fog"))
        {
            inactiveFog.start();
        }

        else
        {
            inactiveCloud.start();
        }

    }


    private void FixedUpdate()
    {
         //Vector3 regularSpeed = new Vector3( 0f, maxSpeed, 0f) ;

        if(isActive == true && !gameObject.CompareTag("Fog"))
        {
            rb.AddForce(nuage * maxSpeed); //Faire en sorte à ce que ce soit controlé par des tags aussi
        }
    }


    private void Update()
    {
        Fog.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        inactiveFog.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        
        Cloud.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        inactiveCloud.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    public override void CustomActivation()
    {
        Debug.Log("IT IS PAINTED");
        sp.isTrigger = true;
        rb.isKinematic = false; 
        isActive = true;

        if(gameObject.CompareTag("Cloud"))
        {
            Cloud.start();
            inactiveCloud.setPaused(true);
        }

        if (gameObject.CompareTag("Fog"))
        {
            Fog.start();
            inactiveFog.setPaused(true);
        }
    }

    public override void CustomDeactivation()
    {
        isActive = false;

        Debug.Log("DO NOT paint");
        sp.isTrigger = false;
        rb.isKinematic = true;



        if (gameObject.CompareTag("Fog"))
        {
            inactiveFog.setPaused(false);
            Fog.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        if (gameObject.CompareTag("Cloud"))
        {
            inactiveCloud.setPaused(false);
            Cloud.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

    }
}

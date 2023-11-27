using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterBehaviour : BroColor
{
    public float conveyorForce = 15.0f;     //Pour les cailloux
    public float smallForce = 12.5f;      //Pour le joueur


    private BoxCollider woter;
    public FMOD.Studio.EventInstance wa;
    public FMOD.Studio.EventInstance so;


    private string CurrentScene;


    private void Start()
    {
        woter = GetComponent<BoxCollider>();
        woter.isTrigger = false;
        wa = FMODUnity.RuntimeManager.CreateInstance("event:/Environement/Water");
        so = FMODUnity.RuntimeManager.CreateInstance("event:/InteractiveEnvironement/Fall_in_Water"); 

        wa.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        CurrentScene = SceneManager.GetActiveScene().name;
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
            Debug.Log("Ah, shinda");
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
            SceneManager.LoadScene(CurrentScene);
        }

        if (isActive == true && other.CompareTag("Rock") && !other.CompareTag("Cloud") && !other.CompareTag("Fog") && !other.CompareTag("Ground"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.forward * conveyorForce, ForceMode.Acceleration);
        }

    }
}


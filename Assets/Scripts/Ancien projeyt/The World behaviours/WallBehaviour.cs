using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : BroColor 
{
    Collider wally;
    //MeshRenderer rendo;
    [SerializeField] ActivateObject act;
    [SerializeField] Renderer wallRenderer;
    [SerializeField] KeyScript key;



    void Start()
    {
        wally = GetComponent<Collider>();
        wally.isTrigger = false;

       // rendo = GetComponent<MeshRenderer>();
    }

    public override void CustomActivation()
    {
        isActive = true;  
        wallRenderer.material.color = Color.grey;
    }

    public override void CustomDeactivation()
    {
        isActive = false; 
        wally.isTrigger = false;

        //rendo.enabled = true;
        wallRenderer.material.color = Color.white;
    }


    private void Update()
    {
        if(isActive == true && key.generator == true)
        {
            wally.isTrigger = true; 
        }
    }


   /* void KeyActivate()
    {

    }*/

    /*private void OnCollisionEnter(Collision collision)
    {
        if(isActive && collision.collider.CompareTag("Key"))
        {
            act.activateObj -= 2f; 
            act.B.setParameterByName("BGM_Para", act.activateObj);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }*/

}

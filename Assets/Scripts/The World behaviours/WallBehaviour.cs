using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : BroColor 
{
    Collider wally;
    MeshRenderer rendo;
    [SerializeField] ActivateObject act; 

    void Start()
    {
        wally = GetComponent<Collider>();
        wally.isTrigger = false;

        rendo = GetComponent<MeshRenderer>();
    }

    public override void CustomActivation()
    {
        isActive = true;       
    }

    public override void CustomDeactivation()
    {
        isActive = false; 
        wally.isTrigger = false;

        rendo.enabled = true; 
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(isActive && collision.collider.CompareTag("Key"))
        {
            act.activateObj -= 2f; 
            act.B.setParameterByName("BGM_Para", act.activateObj);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

}

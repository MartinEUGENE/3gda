using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBehaviour : BroColor 
{

    public BoxCollider sandy;
    
    public CharacterControls chara; 

    void Start()
    {
        sandy.isTrigger = false;
    }

    protected override void CustomActivation()
    {
        sandy.isTrigger = true; 
    }

    protected override void CustomDeactivation()
    {
        sandy.isTrigger = false; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isActive && other.CompareTag("Player"))
        {
            chara.walkspeed -= 3f; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        chara.walkspeed += 3f;
    }

}

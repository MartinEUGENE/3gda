using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBehaviour : BroColor 
{

    public BoxCollider sandy;    
    public CharacterControls chara;

    GameObject storeInside;

    void Start()
    {
        sandy.isTrigger = false;
    }

    public override void CustomActivation()
    {
        sandy.isTrigger = true;
        isActive = true; 
    }

    public override void CustomDeactivation()
    {
        sandy.isTrigger = false;
        isActive = false; 
        if (storeInside != null)
        {
            chara.walkspeed += 3f;
            storeInside = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isActive && other.CompareTag("Player"))
        {
            chara.walkspeed -= 3f;
            storeInside = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(isActive && other.CompareTag("Player"))
        {
            chara.walkspeed += 3f;
            storeInside = null;
        }
    }

}

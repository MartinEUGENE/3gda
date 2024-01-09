using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBehaviour : BroColor 
{

    public BoxCollider sandy;    
    public CharacterControls chara;

    [SerializeField] Renderer sandRenderer;


    GameObject storeInside;

    void Start()
    {
        sandy.isTrigger = false;
    }

    public override void CustomActivation()
    {
        sandy.isTrigger = true;
        sandRenderer.material.color = Color.yellow;

        isActive = true; 
    }

    public override void CustomDeactivation()
    {
        sandy.isTrigger = false;
        isActive = false;

        sandRenderer.material.color = Color.yellow;

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

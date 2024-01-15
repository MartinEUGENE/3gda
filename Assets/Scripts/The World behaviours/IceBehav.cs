using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBehav : BroColor
{

    public BoxCollider ice;
    public CharacterControls chara;


    [SerializeField] Renderer iceRenderer; 

    void Start()
    {
        //  ice.isTrigger = true;
        iceRenderer = GetComponent<Renderer>();
    }

    public override void CustomActivation()
    {
        ice.isTrigger = true;
        iceRenderer.material.color = Color.cyan; 

    }

    public override void CustomDeactivation()
    {
        ice.isTrigger = false;
        iceRenderer.material.color = Color.white;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            chara.walkspeed += 15f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            chara.walkspeed -= 15f;
        }
    }

}

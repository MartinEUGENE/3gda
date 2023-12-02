using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBehav : BroColor
{

    public BoxCollider ice;
    public CharacterControls chara;

    void Start()
    {
      //  ice.isTrigger = true;
    }

    protected override void CustomActivation()
    {
        ice.isTrigger = true;
    }

    protected override void CustomDeactivation()
    {
        ice.isTrigger = false;
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

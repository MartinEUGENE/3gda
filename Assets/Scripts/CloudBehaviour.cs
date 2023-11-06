using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : BroColor
{
    public SphereCollider cloud;
    public ColorControl color; 
    public bool active = true;

    private void Start()
    {
        cloud = GetComponent<SphereCollider>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(cloud != null && active == true)
        {
            cloud.enabled = false;
            active = false; 
        }
        
    }
}

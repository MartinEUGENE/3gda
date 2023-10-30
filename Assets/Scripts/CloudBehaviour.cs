using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : ColorControl
{
    public SphereCollider cloud;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : ColorControl
{
    public float conveyorForce = 10.0f;
    public bool active = false;
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null || active == true)
        {
            //Debug.Log("Object Name: ");
            rb.AddForce(transform.forward * conveyorForce, ForceMode.Force);
        }
    }
    // le forward c'est Z
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}

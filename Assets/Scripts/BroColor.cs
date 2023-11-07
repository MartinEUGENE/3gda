using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BroColor : MonoBehaviour
{
    public ColorControl colorControl;
    
    private Renderer objectRenderer; // Reference to the object's renderer
    private Color originalColor; // Store the original color

    public Rigidbody rb;
    private bool isActive = false; 


    private void Start()
    {
        //originalColor = objectRenderer.material.color; // Store the original color
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform == transform)
                {
                    ToggleActivation();
                }
            }
        }
    }

    protected virtual void CustomActivation()
    {

    }

    protected virtual void CustomDeactivation()
    {

    }

    public void ToggleActivation()
    {
        bool prevActiveState = isActive;
        isActive = !isActive;

        /*if(gameObject.CompareTag("Rock") && isActive == false)
        {
            isActive = true;

            //startUp.Invoke(); // Trigger the startUp event for this specific object
            Debug.Log("painted");
            rb.useGravity = true;
            rb.isKinematic = false;
           // objectRenderer.material.color = Color.green; // Change the color to blue when activated
        }

        else
        {
            isActive = false; 
            Debug.Log("NO paint");
            rb.useGravity = false;
            rb.isKinematic = true;
            //objectRenderer.material.color = originalColor; // Restore the original color when deactivated
        }*/
        
        
        if(gameObject.CompareTag("Cloud") && isActive == false)
        {
            Debug.Log("painted");
            isActive = true;
            GetComponent<SphereCollider>().enabled = true;
            GetComponent<SphereCollider>().isTrigger = true; 

        }

        if (gameObject.CompareTag("Cloud") && isActive == true)
        {
            Debug.Log("NO paint");
            isActive = false;
            GetComponent<SphereCollider>().enabled = false;
        }

        if (!prevActiveState && isActive)
        {
            CustomActivation();
            GetComponent<Renderer>().material.color = Color.red;
        }else if(prevActiveState && !isActive)
        {
            CustomDeactivation();
            GetComponent<Renderer>().material.color = Color.white;
        }

    }

}






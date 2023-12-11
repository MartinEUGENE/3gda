using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class BroColor : MonoBehaviour
{
    [SerializeField] int activateObj; 

    private Renderer objectRenderer; // Reference to the object's renderer
    private Color originalColor; // Store the original color

    public Material originalMat;
    public Material compColor;

    public Rigidbody rb;
    public bool isActive = false;


    public virtual void CustomActivation()
    {
        
    }

    public virtual void CustomDeactivation()
    {
        
    }

  

}


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


/*if(gameObject.CompareTag("Cloud") && isActive == false)
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
}*/





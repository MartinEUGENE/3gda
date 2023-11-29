using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class BroColor : MonoBehaviour
{
    
    private Renderer objectRenderer; // Reference to the object's renderer
    private Color originalColor; // Store the original color

    public Material originalMat;
    public Material compColor;

    public Rigidbody rb;
    public bool isActive = false;

    public FMOD.Studio.EventInstance paint;
    public FMOD.Studio.EventInstance B;


    public int count = 0;
    public int maxCount = 10; 



    private void Start()
    {
        //originalColor = objectRenderer.material.color; // Store the original color
        //rb = GetComponent<Rigidbody>();
        paint = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Character_Paint");
        B = FMODUnity.RuntimeManager.CreateInstance("event:/BGM/BGM");

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                //paint.start();
                FMODUnity.RuntimeManager.PlayOneShot("event:/Character/Character_Paint");

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

        if (!prevActiveState && isActive)
        {
            CustomActivation();                       
            GetComponent<Renderer>().material.color = Color.red;

            paint.setParameterByNameWithLabel("Activation", "Active");

            if (gameObject.CompareTag("River"))
            {
                GetComponent<Renderer>().material.color = Color.blue;
                
            }             

            if (gameObject.CompareTag("Sand"))
            {
                GetComponent<Renderer>().material.color = Color.yellow;
            }

            if (gameObject.CompareTag("Ice"))
            {
                GetComponent<Renderer>().material.color = Color.cyan;
            }

            if (gameObject.CompareTag("Magnet"))
            {
                GetComponent<Renderer>().material.color = Color.black;

            }
        }
        
        else if(prevActiveState && !isActive)
        {
            CustomDeactivation();
            B.setParameterByName("BGM", count);
            GetComponent<Renderer>().material.color = Color.white;
            paint.setParameterByNameWithLabel("Activation", "Desactivation");
            

        }

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





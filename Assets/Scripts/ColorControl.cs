using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorControl : MonoBehaviour
{
    private bool isActive = false;
    public Rigidbody rb;
    public UnityEvent startUp;
  //  public Renderer objectRenderer; // Reference to the object's renderer

    private Color originalColor; // Store the original color

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //originalColor = objectRenderer.material.color; // Store the original color
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

    void ToggleActivation()
    {
        isActive = !isActive;

        if (isActive)
        {
            startUp.Invoke(); // Trigger the startUp event for this specific object
            Debug.Log("painted");
            rb.useGravity = true;
            rb.isKinematic = false; 
           // objectRenderer.material.color = Color.blue; // Change the color to blue when activated
        }
        else
        {
            Debug.Log("NO paint");
            rb.useGravity = false;
            rb.isKinematic = true;
            //objectRenderer.material.color = originalColor; // Restore the original color when deactivated
        }
    }
}
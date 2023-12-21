using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{ 
    
    public float activateObj;

    public FMOD.Studio.EventInstance paint;
    public FMOD.Studio.EventInstance B;
    

    private void Start()
    {
        //originalColor = objectRenderer.material.color; // Store the original color
        //rb = GetComponent<Rigidbody>();
        paint = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Character_Paint");
        B = FMODUnity.RuntimeManager.CreateInstance("event:/BGM/BGM_");

        B.start();

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                paint.start();
                Debug.Log(B.isValid());

                if (hit.collider.GetComponent<BroColor>())
                {                    
                    ToggleActivation(hit.collider.gameObject);
                    Debug.Log(activateObj);
                }
                else
                {
                    BroColor brocol = hit.transform.GetComponentInParent<BroColor>();
                    if (brocol != null)
                    {
                        ToggleActivation(brocol.gameObject);
                    }
                }
            }
        }
    }

    public void ToggleActivation(GameObject obj)
    {
        bool isActive = obj.GetComponent<BroColor>().isActive;

        bool prevActiveState = isActive;
        isActive = !isActive;

        if (!prevActiveState && isActive)
        {
            activateObj +=1f;
            obj.GetComponent<BroColor>().CustomActivation();
            obj.GetComponent<Renderer>().material.color = Color.red;
            B.setParameterByName("BGM_Para", activateObj);


            paint.setParameterByNameWithLabel("Activation", "Active");

            if (obj.gameObject.CompareTag("River"))
            {
                obj.GetComponent<Renderer>().material.color = Color.blue;
            }

            if (obj.gameObject.CompareTag("Sand"))
            {
                obj.GetComponent<Renderer>().material.color = Color.yellow;
            }

            if (obj.gameObject.CompareTag("Ice"))
            {
                obj.GetComponent<Renderer>().material.color = Color.cyan;
            }

            if (obj.gameObject.CompareTag("Magnet"))
            {
                obj.GetComponent<Renderer>().material.color = Color.black;

            }

            if (obj.gameObject.CompareTag("Cloud"))
            {
                obj.GetComponent<Renderer>().material.color = Color.white;
            }

            if (obj.gameObject.CompareTag("Key"))
            {
                obj.GetComponent<Renderer>().material.color = Color.green;
            }

            if (obj.gameObject.CompareTag("Wall"))
            {
                obj.GetComponent<Renderer>().material.color = Color.magenta;
            }
        }

        else if (prevActiveState && !isActive)
        {
            activateObj--;
            obj.GetComponent<BroColor>().CustomDeactivation();
            B.setParameterByName("BGM_Para", activateObj);
            obj.GetComponent<Renderer>().material.color = Color.white;
            paint.setParameterByNameWithLabel("Activation", "Desactivation");

        }

    }
}

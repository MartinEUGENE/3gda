using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    [SerializeField] int activateObj;

    public FMOD.Studio.EventInstance paint;
    public FMOD.Studio.EventInstance B;
    

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

                if (hit.collider.GetComponent<BroColor>())
                {
                    ToggleActivation(hit.collider.gameObject);
                    Debug.Log(activateObj);
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
            activateObj++;
            obj.GetComponent<BroColor>().CustomActivation();
            obj.GetComponent<Renderer>().material.color = Color.red;

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
        }

        else if (prevActiveState && !isActive)
        {
            activateObj--;
            obj.GetComponent<BroColor>().CustomDeactivation();
            B.setParameterByName("BGM", activateObj);
            obj.GetComponent<Renderer>().material.color = Color.white;
            paint.setParameterByNameWithLabel("Activation", "Desactivation");

        }

    }
}

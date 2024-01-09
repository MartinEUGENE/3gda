using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{ 
    
    public float activateObj;

    public FMOD.Studio.EventInstance paint;
    public FMOD.Studio.EventInstance B;


    [SerializeField] List<GameObject> stockedObjects = new List<GameObject>();  
    

    private void Start()
    {
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

                BroColor brocol = hit.transform.GetComponentInParent<BroColor>();

                if (hit.collider.GetComponent<BroColor>() && brocol.isActive == false)
                {                    
                    ToggleActivation(hit.collider.gameObject);
                    Debug.Log(activateObj);
                }

                else
                {
                    //BroColor brocol = hit.transform.GetComponentInParent<BroColor>();
                    if (brocol != null)
                    {
                        ToggleActivation(brocol.gameObject);
                        //stockedObjects.Remove(brocol.gameObject);
                    }
                }
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            foreach(GameObject playObject in stockedObjects)
            {
                activateObj = 0;
                B.setParameterByName("BGM_Para", activateObj);
                playObject.GetComponent<BroColor>().CustomDeactivation(); 
            }

            stockedObjects.RemoveRange(0, stockedObjects.Count);
            //bro.TrueDesactivation();    
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Teleporter"))
        {
            foreach (GameObject playObject in stockedObjects)
            {
                activateObj = 1;
                B.setParameterByName("BGM_Para", activateObj);
                playObject.GetComponent<BroColor>().CustomDeactivation();
            }

            stockedObjects.RemoveRange(0, stockedObjects.Count);
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
            stockedObjects.Add(obj);

            obj.GetComponent<BroColor>().CustomActivation();
            B.setParameterByName("BGM_Para", activateObj);

            paint.setParameterByNameWithLabel("Activation", "Active");


           if (obj.gameObject.CompareTag("Cloud"))
            {
                obj.GetComponent<Renderer>().material.color = Color.grey;
            }

            if (obj.gameObject.CompareTag("Fog"))
            {
                obj.GetComponent<Renderer>().material.color = Color.cyan;
            }
        }

        else if (prevActiveState && !isActive)
        {
            activateObj--;
            stockedObjects.Remove(obj);

            obj.GetComponent<BroColor>().CustomDeactivation();
            B.setParameterByName("BGM_Para", activateObj);
            obj.GetComponent<Renderer>().material.color = Color.white;
            paint.setParameterByNameWithLabel("Activation", "Desactivation");


            /*if (obj.gameObject.CompareTag("Rock"))
            {
                obj.GetComponent<RockBehaviour>().count -= 1;
                Debug.Log("do it");
            }*/
        }

    }
}

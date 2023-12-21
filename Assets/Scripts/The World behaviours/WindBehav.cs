using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBehav : MonoBehaviour
{
    public float windForce;
    public float playerForce;
    public float objForce;
        
    //Variable pour le vecteur de force
    public Vector3 windVar;

    private Collider windo;
    public FMOD.Studio.EventInstance wind;

    void Start()
    {
        windo = GetComponent<Collider>();
        windo.isTrigger = true; 

        wind = FMODUnity.RuntimeManager.CreateInstance("event:/Environement/Wind");
    }

    private void Update()
    {
        wind.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Fog"))
        {
            other.GetComponent<Rigidbody>().AddForce(windVar * windForce, ForceMode.Acceleration);
        }

        if(other.CompareTag("Cloud"))
        {
            other.GetComponent<Rigidbody>().AddForce(windVar * windForce, ForceMode.Force);
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(windVar * playerForce, ForceMode.Force);
        }

        if (other.CompareTag("Rock") && other.CompareTag("Key"))
        {
            other.GetComponent<Rigidbody>().AddForce(windVar * objForce, ForceMode.Force);
        }
    }

}

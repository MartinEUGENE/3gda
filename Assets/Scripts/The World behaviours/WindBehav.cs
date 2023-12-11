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
    void Start()
    {
        windo = GetComponent<Collider>();
        windo.isTrigger = true; 
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Cloud") && other.CompareTag("Fog"))
        {
            other.GetComponent<Rigidbody>().AddForce(windVar * windForce, ForceMode.Acceleration);
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(windVar * playerForce, ForceMode.Force);
        }

        if (!other.CompareTag("Cloud"))
        {
            other.GetComponent<Rigidbody>().AddForce(windVar * objForce, ForceMode.Force);
        }

        if(other.CompareTag("Ventilator"))
        {
            other.GetComponent<Rigidbody>().AddForce(windVar * 0);
        }

    }

}

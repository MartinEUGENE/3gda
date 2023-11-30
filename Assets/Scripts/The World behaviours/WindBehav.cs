using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBehav : MonoBehaviour
{
    public float windForce = 25f;
    public float smallForce = 15f;
    public float small = 5f;

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
            other.GetComponent<Rigidbody>().AddForce(transform.up * windForce, ForceMode.Acceleration);
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * smallForce, ForceMode.Force);
            Debug.Log("Yo");
        }

        if (!other.CompareTag("Cloud"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * small, ForceMode.Force);
        }

        if(other.CompareTag("Ventilator"))
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * 0);
        }

    }

}

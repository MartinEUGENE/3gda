using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : BroColor
{
    [SerializeField] WallBehaviour wall;
    [SerializeField] WaterBehaviour stream;
    [SerializeField] Ventilator storm;
    [SerializeField] Renderer king;

    public bool generator = false;
    public bool windTouch = false;
    public bool waterTouch = false;


    private void Start()
    {
        king = GetComponent<Renderer>();
    }

    public override void CustomActivation()
    {
        isActive = true;
        king.material.color = Color.green;
    }

    public override void CustomDeactivation()
    {
        isActive = false;
        generator = false;
        windTouch = false;
        waterTouch = false;

        king.material.color = Color.white;
    }


    private void Update()
    {
        Generator();
    }

    public void Generator()
    {
        if(windTouch == true || waterTouch == true)
        {
            generator = true; 
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (isActive == true && other.CompareTag("wind") || other.CompareTag("River"))
        {
            if(storm.isActive == true)
            {
                windTouch = true; 
            }

            if(stream.isActive == true)
            {
                waterTouch = true; 
            }
        }
    }


}
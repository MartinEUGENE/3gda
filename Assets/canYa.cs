using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canYa : MonoBehaviour
{
    public RectTransform rect; 
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
       {
            rect.localPosition = new Vector3(rect.localPosition.x - 2f, rect.localPosition.y,rect.localPosition.z);
       }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }*/


    private void OnTriggerEnter2D(Collider2D collision)
     {
         Debug.Log("CREVE");
         Destroy(gameObject);
     }

}

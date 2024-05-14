using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookProjectile : MonoBehaviour
{
    private Transform transform;


    void Start()
    {
        transform = gameObject.transform;
    }

    void Update()
    {
        //transform.localRotation = Quaternion.Euler(0,0,0);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}

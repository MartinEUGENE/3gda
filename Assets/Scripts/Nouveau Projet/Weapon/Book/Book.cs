using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{

    //public float Level;

    //public float Radius;

    //public float Damages;
    //private float booksNumbers;
    public float Speed;
    private float x;


    void Start()
    {
        x = 0.0f;
    }



    void Update()
    {
            x += Time.deltaTime * Speed;
            transform.localRotation = Quaternion.Euler(0, 0, x);
    }
}

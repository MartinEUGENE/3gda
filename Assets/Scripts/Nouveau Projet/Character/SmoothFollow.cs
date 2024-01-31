using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;

    Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        offset = transform.position - target.position; 
    }

    void FixedUpdate()
    {
        Vector3 movPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movPos, ref velocity, damping);
    }
}
        
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationThing : MonoBehaviour
{
    public Vector3 mousePos;
    public Camera mainCam;
    private void Start()
    {
        mainCam = FindObjectOfType<Camera>();
    }


    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        Vector3 rotat = transform.position - mousePos; 
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    [HideInInspector]
    public Vector3 mousPos;
    public float destroyObj = 5f;
    public Camera mainCam;

    public WeaponStats weapon;


    protected virtual void Start()
    {
        Destroy(gameObject, destroyObj);
        mainCam = FindObjectOfType<Camera>(); 
    }

    protected virtual void Update()
    {
        mousPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousPos - transform.position;
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot);        
    }
    public virtual void VerifDir(Vector3 dir)
    {
        mousPos = dir; 
    }

}

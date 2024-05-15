using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProjectile : MonoBehaviour
{
    private float timer = 2;
    private float timerActiveCollider = 0.5f;

    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }


    void Update()
    {
        timer -= Time.deltaTime;
        timerActiveCollider -= Time.deltaTime;
        if(timer <= 0f) Destroy(gameObject);
        transform.eulerAngles = new Vector3(0, 0, 0);
        if(timerActiveCollider <= 0f) gameObject.GetComponent<Collider2D>().enabled = true;
    }
}

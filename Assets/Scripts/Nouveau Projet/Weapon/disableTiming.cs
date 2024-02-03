using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableTiming : MonoBehaviour
{
    public float timeDisable = 0.6f;
    float timer;

    private void OnEnable()
    {
        timer = timeDisable; 
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if(timer<0f)
        {
            gameObject.SetActive(false);
        }
    }
}

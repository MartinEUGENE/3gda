using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAfter : MonoBehaviour
{
    public GameObject eliteSpawn;
    public float seconds;

    bool eliteSpawned; 
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("");
    }

    private void Update()
    {
        seconds -= Time.deltaTime; 
        if(seconds <= 0f)
        {
            SpawnTheEnemy(); 

        }
    }

    void SpawnTheEnemy()
    {
        FMODUnity.RuntimeManager.PlayOneShot("");
        Instantiate(eliteSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject); 
    }

}


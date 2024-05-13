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

    IEnumerator SpawnTheEnemy()
    {
        new WaitForSeconds(seconds);
        Instantiate(eliteSpawn);
        FMODUnity.RuntimeManager.PlayOneShot("");
        Destroy(gameObject);

        yield return eliteSpawned = true; 
    }
}


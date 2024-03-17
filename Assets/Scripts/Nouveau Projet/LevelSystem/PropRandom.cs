using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandom : MonoBehaviour
{

    public List<GameObject> propSpawn;
    public List<GameObject> propPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnProp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProp()
    {
        foreach(GameObject sp in propSpawn)
        {
            int randi = Random.Range(0, propPrefab.Count);
            GameObject prop = Instantiate(propPrefab[randi], sp.transform.position, Quaternion.identity);
            prop.transform.parent = sp.transform;
        }
    }
}

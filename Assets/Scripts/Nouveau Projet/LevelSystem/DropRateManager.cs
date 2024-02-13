using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        public string name;
        public GameObject itemPrefab;
        public float dropRate; 
    }

    public List<Drops> drop;

    void OnDestroy()
    {
        float randomNmb = UnityEngine.Random.Range(0f, 100f);
        List<Drops> possibility = new List<Drops>();

        foreach(Drops rate in drop)
        {
            if(randomNmb <= rate.dropRate)
            {
                possibility.Add(rate);
            }
        }

        if(possibility.Count > 0)
        {
            Drops drops = possibility[UnityEngine.Random.Range(0, possibility.Count)];
            Instantiate(drops.itemPrefab, transform.position, Quaternion.identity);
        }

    }
}

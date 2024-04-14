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

    public void TryDrop()
    {
        float randomNmb = Random.Range(0f, 100f);
        //List<Drops> possibility = new List<Drops>();

        foreach(Drops rate in drop)
        {
            if(randomNmb <= rate.dropRate)
            {
                //  possibility.Add(rate);
                Instantiate(rate.itemPrefab, transform.position, Quaternion.identity);

            }
        }

        /*if(possibility.Count > 0)
        {
            Drops drops = possibility[Random.Range(0, possibility.Count)];
        }*/

    }
}

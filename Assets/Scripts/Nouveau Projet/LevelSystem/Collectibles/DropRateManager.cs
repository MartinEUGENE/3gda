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
    public float LaunchForce = 100f;
    public float Drag = 5f; 

    public void TryDrop()
    {
        Yeet();
    }

    public void Yeet()
    {
        float randomNmb = Random.Range(0f, 100f);

        foreach (Drops rate in drop)
        {
            if(randomNmb <= rate.dropRate)
            {
                Instantiate(rate.itemPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));

                Rigidbody2D pref = rate.itemPrefab.GetComponent<Rigidbody2D>();
                pref.AddForce(rate.itemPrefab.transform.up * LaunchForce); // donne une force de déplacement selon l'angle
                pref.drag = Drag;
            }
        }
    }
}

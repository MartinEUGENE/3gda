using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mine : MonoBehaviour
{
    public GameObject MinePrefab;
    public float MineNumber;
    public float LaunchForce;
    private Transform form;
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            MineFire();
        }
    }

    public void MineFire()
    {
        for(int i = 0; i < MineNumber; i++)
        {
            GameObject NewMine = Instantiate(MinePrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0,360)));
            Rigidbody2D mineRB = NewMine.GetComponent<Rigidbody2D>();
            mineRB.AddForce(NewMine.transform.up *LaunchForce);
        }

    }
}

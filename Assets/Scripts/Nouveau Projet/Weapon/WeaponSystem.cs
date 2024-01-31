using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public int damage = 5; 
    public  int range = 1;
    public float cooldown = 1.0f;
    
     [SerializeField] float fireRate = 1.0f;
     public int level = 1; 

    public virtual void Shoot()
    {

    }

    public virtual void WeaponAttributes()
    {

    }

    public virtual void ArmaDeck()
    {

    }

}

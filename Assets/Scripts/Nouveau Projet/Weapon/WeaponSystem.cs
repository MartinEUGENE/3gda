using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] float damage = 0f;
    [SerializeField] int range = 1;
    [SerializeField] float cooldown = 1.0f;
    [SerializeField] float fireRate = 1.0f;
    [SerializeField] int level = 1; 

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

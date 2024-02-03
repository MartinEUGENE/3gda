using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehav : BulletSystem
{
    FirstWeapon weep;

    protected override void Start()
    {
        base.Start();
        weep = FindObjectOfType<FirstWeapon>();
    }

     void Update()
    {
        transform.position += dir * weep.speedrange * Time.deltaTime;

    }

}

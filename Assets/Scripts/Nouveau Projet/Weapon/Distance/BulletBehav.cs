using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehav : BulletSystem
{
    
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        transform.position += mousPos * weapon.speedrange * Time.deltaTime; 
    }

    
}

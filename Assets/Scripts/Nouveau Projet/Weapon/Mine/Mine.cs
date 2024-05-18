using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mine : WeaponSystem
{
    public GameObject MinePrefab;
    public int MineNumber;
    public float LaunchForce;

    [Header ("Projectile Metrics")]

    public float Drag;
    public float Damages;
    public float Radius;
    public float MineLifeDuration;

    protected override void Start()
    {
        base.Start();

        if(weaponData.Level > 3)
        {
            MineNumber = 3; 
        }
        else
        {
            MineNumber = weaponData.Level;
        }
    }

    protected override void Update()
    {
        weaponData.cooldown -= Time.deltaTime;

        if (weaponData.Cooldown <= 0f)
        {
            Shoot();
            MineFire(); 
        }
    }

    protected override void Shoot()
    {
        base.Shoot();        
    }

    public void MineFire()
    {
        for(int i = 0; i < MineNumber; i++)
        {
            GameObject NewMine = Instantiate(MinePrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0,360))); //spawn avec un angle random
           
            Rigidbody2D MineRB = NewMine.GetComponent<Rigidbody2D>();
            MineProjectile MinePR = NewMine.GetComponent<MineProjectile>();

            MineRB.AddForce(NewMine.transform.up *LaunchForce); // donne une force de déplacement selon l'angle
            MineRB.drag = Drag;             //ici je donnes les metrics de la mineprojectile
            
            MinePR.Radius = Radius;
            MinePR.Damages = Damages;
            MinePR.timerLife = MineLifeDuration;

        }

    }
}

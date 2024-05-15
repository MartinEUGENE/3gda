using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mine : MonoBehaviour
{
    public GameObject MinePrefab;
    public float MineNumber;
    public float LaunchForce;
    private Transform form;

    [Header ("Projectile Metrics")]

    public float Drag;
    public float Damages;
    public float Radius;
    public float MineLifeDuration;
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            MineFire(); // ici le trigger pour lancer les projectiles, faites comme vous voulez (utilisez un timer si vous voulez automatiser c'est plus simple)
        }
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

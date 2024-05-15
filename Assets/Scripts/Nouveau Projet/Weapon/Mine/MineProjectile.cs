using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProjectile : MonoBehaviour
{

    private float timerActiveCollider = 0.5f;

    [Header ("Valeurs données par le launcher")]
    public float timerLife;
    public float Radius;
    public float Damages;

    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }


    void Update()
    {
        timerLife -= Time.deltaTime;
        timerActiveCollider -= Time.deltaTime;


        if(timerLife <= 0f) 
        {
            // ici la mine explose donc faites comme vous voulez pour les dégats 
            // persd j'opterai pour faire spawn un objet rond avec le radius de la variable Radius 
            // les valeurs des variables Raduis & Damages sont données dans le launcher !!!! 
            Destroy(gameObject);
        }

        transform.eulerAngles = new Vector3(0, 0, 0); //ici je force le sprite à être droit , à retirer si il n'y a pas de collider
        if(timerActiveCollider <= 0f) gameObject.GetComponent<Collider2D>().enabled = true; //ici je réactive les collisions
    }
}

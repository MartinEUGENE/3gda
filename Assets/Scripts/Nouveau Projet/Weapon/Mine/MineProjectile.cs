using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProjectile : MeleeWeapon
{
    private float timerActiveCollider = 0.5f;

    [Header ("Valeurs données par le launcher")]
    public float timerLife;
    public float Radius;
    public float Damages;
    public GameObject explosion; 

    protected override void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        stats = GetComponentInParent<CharacterStats>();
        OnSpawn();
    }
    protected override void Update()
    {
        inateCrit = Random.Range(1, 100);
        timerLife -= Time.deltaTime;
        timerActiveCollider -= Time.deltaTime;

        if (timerLife <= 0f)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Radius = weapon.Quantity; 
            gameObject.GetComponent<CircleCollider2D>().radius = Radius;

            // ici la mine explose donc faites comme vous voulez pour les dégats 
            // persd j'opterai pour faire spawn un objet rond avec le radius de la variable Radius 
            // les valeurs des variables Raduis & Damages sont données dans le launcher !!!! 

            Destroy(gameObject);
        }

        transform.eulerAngles = new Vector3(0, 0, 0); //ici je force le sprite à être droit , à retirer si il n'y a pas de collider
        if (timerActiveCollider <= 0f) gameObject.GetComponent<Collider2D>().enabled = true; //ici je réactive les collisions
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
            EnemiesSystem enemy = other.GetComponent<EnemiesSystem>();

            enemy.knockDuration = weapon.KnockbackDuration;
            enemy.knockForce = weapon.Knockback;

            enemy.TakeDmg(GetCurrentDamage(), hasCrit);
            markedEnemies.Add(other.gameObject);
        }
    }
    protected override void OnSpawn()
    {
        base.OnSpawn();
        Damages = weapon.Damage;

        timerLife = destroyObj; 
    }
}

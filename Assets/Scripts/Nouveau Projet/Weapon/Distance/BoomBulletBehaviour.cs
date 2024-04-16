using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBulletBehaviour : BulletSystem
{
    List<GameObject> markedEnemies;

    public int countDown = 0;
    public GameObject explosion;

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>();

    }

    protected override void Update() // il tire dans la bonne direction mais une force suplémentaire le pousse dans la direction où se déplace le joueur, démontré par le fait que la balle est plus lente quand tiré loing du joueur
    {
        base.Update();
        transform.position += moveDir * weapon.speedrange * Time.deltaTime;

        countDown += 1;
        if (countDown >= 40)
        {
            Boom();
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
            //EnemiesSystem en = other.GetComponent<EnemiesSystem>();
            //en.TakeDmg(GetCurrentDamage(), hasCrit);
            //Debug.Log(GetCurrentDamage());
            markedEnemies.Add(other.gameObject);
            Boom();
            
        }
    }

    /*public int GetCurrentDamage()
    {
        return stats.currentAttack + weapon.damage;
    }*/

    public void Boom()
    {
        if (weapon.quantity == 3f)
        {
            GameObject explosionObject = Instantiate(explosion, transform.position, Quaternion.identity);
            explosionObject.transform.localScale = new Vector3(2f, 2f, 1f);
           // Debug.Log("bum");
        }
        else
        {
            //Debug.Log("lul");
            Instantiate(explosion, transform.position, Quaternion.identity);

        }

        //Debug.Log(weapon.quantity);
        Destroy(gameObject);
    }
}

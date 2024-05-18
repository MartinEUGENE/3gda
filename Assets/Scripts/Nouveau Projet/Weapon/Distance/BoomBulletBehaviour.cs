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
        FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Player/Weapon/Secondary Weapons/Fireworks_Weapon"); 
        markedEnemies = new List<GameObject>();
    }

    protected override void Update() // il tire dans la bonne direction mais une force supl�mentaire le pousse dans la direction o� se d�place le joueur, d�montr� par le fait que la balle est plus lente quand tir� loing du joueur
    {
        base.Update();
        transform.position += moveDir * weapon.Speedrange * Time.deltaTime;

        countDown += Mathf.FloorToInt(1 * Time.timeScale); 
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
        Instantiate(explosion, transform.position, Quaternion.identity); //affect scale par lvl a rajouter
        FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Player/Weapon/Secondary Weapons/Fireworks_Explosion");
        Destroy(gameObject);
    }
}

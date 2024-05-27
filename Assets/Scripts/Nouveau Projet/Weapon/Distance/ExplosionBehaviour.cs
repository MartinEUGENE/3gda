using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float destroyObj = 2f;
    public int inateCrit;
    public bool hasCrit;

    public CharacterStats stats;
    public WeaponStats weapon;
    public List<GameObject> markedEnemies;
    public GameObject explosion; 

    protected virtual void Start()
    {
        Destroy(gameObject, destroyObj);
        stats = GetComponentInParent<CharacterStats>();
        OnSpawn();
    }
    protected virtual void Update()
    {
        inateCrit = Random.Range(1, 100);
    }
    public int GetCurrentDamage()
    {
        int dmgResult = Mathf.FloorToInt(stats.CurrentAttack) + weapon.Damage;

        if (stats.CurrentCritRate >= inateCrit)
        {
            dmgResult *= Mathf.FloorToInt(stats.CurrentCritDmg);
            hasCrit = true;
        }

        else
        {
            dmgResult = Mathf.FloorToInt(stats.CurrentAttack) + weapon.Damage;
            hasCrit = false;
        }

        return dmgResult;
    }
    protected virtual void OnSpawn()
    {

    }
    public void Boom()
    {
        Instantiate(explosion, transform.position, Quaternion.identity); //affect scale par lvl a rajouter
        FMODUnity.RuntimeManager.PlayOneShot("event:/New Project/Player/Weapon/Secondary Weapons/Fireworks_Explosion");
        Destroy(gameObject);
    }
}

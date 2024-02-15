using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public float destroyAfter = 2f;
    public WeaponStats weapon;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfter);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemiesSystem en = collision.gameObject.GetComponent<EnemiesSystem>();
            en.TakeDmg(weapon.Damage);
        }
    }
}

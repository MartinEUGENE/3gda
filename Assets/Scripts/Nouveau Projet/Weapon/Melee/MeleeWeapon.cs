using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public Vector3 mousPos;
    public float destroyObj = 2f;
    //public Camera mainCam;

    public CharacterStats stats;
    public WeaponStats weapon;
    protected virtual void Start()
    {
        Destroy(gameObject, destroyObj);
        stats = GetComponentInParent<CharacterStats>();
    }

    /*protected virtual void Update()
    {
        mousPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousPos - transform.position;
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot);
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemiesSystem en = collision.gameObject.GetComponent<EnemiesSystem>();
            en.TakeDmg(weapon.Damage);
        }
    }*/
}

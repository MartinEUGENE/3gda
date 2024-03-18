using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    [HideInInspector]
    public Vector3 mousPos;
    public float destroyObj = 5f;
    public Camera mainCam;

    public WeaponStats weapon;
    public CharacterStats stats;

    //List<GameObject> markedEnemies;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyObj);
        mainCam = FindObjectOfType<Camera>();
        
        //markedEnemies = new List<GameObject>();
    }

    protected virtual void Update()
    {
        mousPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousPos - transform.position;
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot);        
    }
    public virtual void VerifDir(Vector3 dir)
    {
        mousPos = dir; 
    }

   /* protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !markedEnemies.Contains(other.gameObject))
        {
            EnemiesSystem en = other.GetComponent<EnemiesSystem>();
            en.TakeDmg(GetCurrentDamage());
            Debug.Log(GetCurrentDamage());
            markedEnemies.Add(other.gameObject);
        }
    }

    public int GetCurrentDamage()
    {
        return stats.currentAttack + weapon.damage;
    }*/
}

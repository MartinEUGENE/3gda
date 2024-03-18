using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    [HideInInspector]
    public Vector3 mousPos;
    public Vector3 mouseDir;
    public Vector3 moveDir;
    public float destroyObj = 5f;
    public Camera mainCam;

    public WeaponStats weapon;
    public CharacterStats stats;

    //List<GameObject> markedEnemies;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyObj);
        mainCam = FindObjectOfType<Camera>();
        UpdateMouseData();
        moveDir = mouseDir;
        float rot = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
        //markedEnemies = new List<GameObject>();
        stats = FindObjectOfType<CharacterStats>();
    }

    protected virtual void Update()
    {
      
    }

    void UpdateMouseData()
    {
        mousPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mouseDir = mousPos - transform.position;
        mouseDir.z = 0;
        mouseDir.Normalize();
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

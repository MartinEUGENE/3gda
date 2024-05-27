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
    public Rigidbody2D rb; 

    public int inateCrit;
    public bool hasCrit;

    //List<GameObject> markedEnemies;

    protected virtual void Start()
    {
        OnSpawn(); 
        Destroy(gameObject, destroyObj);
        mainCam = FindObjectOfType<Camera>();
        stats = FindObjectOfType<CharacterStats>();
        rb = GetComponent<Rigidbody2D>();
        UpdateMouseData();
        moveDir = mouseDir;
        float rot = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
        //markedEnemies = new List<GameObject>();
    }

    protected virtual void OnSpawn()
    {

    }


    protected virtual void Update()
    {
        inateCrit = Random.Range(1, 100);
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
}

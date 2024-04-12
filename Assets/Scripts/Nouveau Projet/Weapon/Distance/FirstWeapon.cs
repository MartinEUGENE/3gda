using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWeapon : WeaponSystem
{
    public Vector3 mousePos;
    public float destroyObj = 5f;

    protected override void Start()
    {
        mainCam = FindObjectOfType<Camera>();
        Vector3 dir = mousePos - transform.position;
        Vector3 roting = transform.position - mousePos;
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot + 90f);
    }

    protected override void Shoot()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;

        base.Shoot();
        GameObject instantiatedBullet = Instantiate(weaponData.PrefabObj);
        BulletSystem bulletSys = instantiatedBullet.GetComponent<BulletSystem>();

        instantiatedBullet.transform.position = transform.position;

        bulletSys.VerifDir(mousePos);
    }

    protected override void Update()
    {
        base.Update();
       
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWeapon : WeaponSystem
{
    public Vector3 mousPos;
    public float destroyObj = 5f;
    public Camera mainCam;

    protected override void Start()
    {
        mainCam = FindObjectOfType<Camera>();
    }
    protected override void Shoot()
    {
        base.Shoot();
        weaponData.prefabObj = Instantiate(weaponData.PrefabObj);
        weaponData.PrefabObj.transform.position = transform.position;
        weaponData.PrefabObj.GetComponent<BulletSystem>().VerifDir(mousPos);
    }

    protected override void Update()
    {
        base.Update();
        mousPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousPos - transform.position;
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot);
    }
}

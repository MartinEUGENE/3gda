using UnityEngine;
using System.Collections;

public class FirstWeapon : WeaponSystem
{
    public Vector3 mousePos;
    public float destroyObj = 5f;

    protected override void Start()
    {
        base.Start();
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

        StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        for (int i = 0; i < weaponData.Quantity; i++)
        {
            base.Shoot();
            GameObject instantiatedBullet = Instantiate(weaponData.PrefabObj);
            BulletSystem bulletSys = instantiatedBullet.GetComponent<BulletSystem>();

            instantiatedBullet.transform.position = transform.position;

            bulletSys.VerifDir(mousePos);

            yield return new WaitForSeconds(0.15f);
        }
    }

    protected override void Update()
    {
        base.Update();
    }
}

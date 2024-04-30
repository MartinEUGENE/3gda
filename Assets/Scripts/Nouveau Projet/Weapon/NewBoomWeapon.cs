using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBoomWeapon : WeaponSystem
{
    
    public CircleCollider2D boomZone;
    // Start is called before the first frame update
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Shoot()
    {

        base.Shoot();
        float radius = boomZone.radius;

        // Calculate a random angle around the circle (in radians)
        float randomAngle = Random.Range(0f, Mathf.PI * 2f); // 0 to 2 * PI

        // Calculate the position on the circumference of the circle using trigonometry
        float x = transform.position.x + radius * Mathf.Cos(randomAngle);
        float y = transform.position.y + radius * Mathf.Sin(randomAngle);

        if (weaponData.quantity == 3f)
        {
            GameObject explosionObject = Instantiate(weaponData.prefabObj, new Vector3(x, y, 0f), Quaternion.identity);
            explosionObject.transform.localScale = new Vector3(2f, 2f, 1f);
             Debug.Log("bum");
        }
        else
        {
            Debug.Log("lul");
            Instantiate(weaponData.prefabObj, new Vector3(x, y, 0f), Quaternion.identity);

        }

        

    }

}

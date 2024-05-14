using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private float x;
    public WeaponStats weapon;
    public CharacterStats stats;    

    void Start()
    {
        Destroy(gameObject, weapon.WeaponReload);
        x = 0.0f;
        stats = GetComponentInParent<CharacterStats>();
    }

    void Update()
    {
            x += Time.deltaTime * weapon.Speedrange;
            transform.localRotation = Quaternion.Euler(0, 0, x);
    }
}

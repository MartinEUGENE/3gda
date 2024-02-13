using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "Weapon Stats")]

public class WeaponStats : ScriptableObject
{
    [SerializeField]
    int damage; 
    public int Damage { get => damage; protected set => damage = value; } 

    [SerializeField]
    float speedrange; 
    public float Speedrange { get => speedrange; protected set => speedrange = value; } 

    [SerializeField]
    int quantity;    
    public int Quantity { get => quantity; protected set => quantity = value; } 

    [SerializeField]
    float weaponReload; 
    public float WeaponReload { get => weaponReload; protected set => weaponReload = value; }

    [SerializeField]
    //float cooldown;
    public float cooldown;
    //public float Cooldown { get => cooldown; private set => cooldown = value; }

    [SerializeField]
     bool pierceEffect;
    public bool PierceEffect { get => pierceEffect; protected set => pierceEffect = value; }

    [SerializeField]
    GameObject prefabObj;  
    public GameObject PrefabObj { get => prefabObj; protected set => prefabObj = value; } 
}

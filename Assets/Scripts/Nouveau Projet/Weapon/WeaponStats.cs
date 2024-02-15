using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "Weapon Stats")]

public class WeaponStats : ScriptableObject
{
    [SerializeField]
    public int damage; 
    public int Damage { get => damage; protected set => damage = value; } 

    [SerializeField]
    public float speedrange; 
    public float Speedrange { get => speedrange; protected set => speedrange = value; } 

    [SerializeField]
    public int quantity;    
    public int Quantity { get => quantity; protected set => quantity = value; } 

    [SerializeField]
    public float weaponReload; 
    public float WeaponReload { get => weaponReload; protected set => weaponReload = value; }

    [SerializeField]
    //float cooldown;
    public float cooldown;
    public float Cooldown { get => cooldown; private set => cooldown = value; }

    [SerializeField]
    public bool pierceEffect;
    public bool PierceEffect { get => pierceEffect; protected set => pierceEffect = value; }

    [SerializeField]
    public GameObject prefabObj;  
    public GameObject PrefabObj { get => prefabObj; protected set => prefabObj = value; } 
}

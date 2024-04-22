using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable Objects/Weapon Stats")]

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
    public int pierceEffect;
    public int PierceEffect { get => pierceEffect; protected set => pierceEffect = value; }

    [SerializeField]
    public GameObject prefabObj;  
    public GameObject PrefabObj { get => prefabObj; protected set => prefabObj = value; }

    [SerializeField]
    public int level;
    public int Level { get => level; protected set => level = value; }
        
    [SerializeField]
    public Sprite icon; //Pas de modifs pendant le gameplay 
    public Sprite Icon { get => icon; protected set => icon = value; }

    [SerializeField]
    public string named; //Pas de modifs pendant le gameplay 
    public string Named { get => named; protected set => named = value; }

    [SerializeField]
    public string descrip; //Pas de modifs pendant le gameplay 
    public string Descrip { get => descrip; protected set => descrip = value; }

    [SerializeField]
    public GameObject nextWeapon; //Pas de modifs pendant le gameplay 
    public GameObject NextWeapon { get => nextWeapon; protected set => nextWeapon = value; }

}

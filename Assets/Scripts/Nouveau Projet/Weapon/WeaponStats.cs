using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable Objects/Weapon Stats")]

public class WeaponStats : ScriptableObject
{

    [Header("Nom et Description")]

    [SerializeField]
    string named; //Pas de modifs pendant le gameplay 
    public string Named { get => named; protected set => named = value; }

    [SerializeField]
    string descrip; //Pas de modifs pendant le gameplay 
    public string Descrip { get => descrip; protected set => descrip = value; }

    [Header("Stats de l'arme")]

    [SerializeField]
    int level;
    public int Level { get => level; protected set => level = value; }
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
    public float Cooldown { get => cooldown; protected set => cooldown = value; }

    [SerializeField]
    //float cooldown;
    float knockback;
    public float Knockback { get => knockback; protected set => knockback = value; }

    [SerializeField]
    //float cooldown;
    float knockbackDuration;
    public float KnockbackDuration { get => knockbackDuration; protected set => knockbackDuration = value; }

    [SerializeField]
    int pierceEffect;
    public int PierceEffect { get => pierceEffect; protected set => pierceEffect = value; }


    [Header("Prefab Arme")]

    [SerializeField]
    Sprite icon; //Pas de modifs pendant le gameplay 
    public Sprite Icon { get => icon; protected set => icon = value; }

    [SerializeField]
    GameObject prefabObj;
    public GameObject PrefabObj { get => prefabObj; protected set => prefabObj = value; }

    [SerializeField]
    GameObject nextWeapon; //Pas de modifs pendant le gameplay 
    public GameObject NextWeapon { get => nextWeapon; protected set => nextWeapon = value; }

}

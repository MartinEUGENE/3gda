using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character")]

public class CharacterScriptable : ScriptableObject
{
    [Header("Starting Weapon")]
    [SerializeField] 
    GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }
    /*
        [SerializeField]
        GameObject startingPassive;
        public GameObject StartingPassive { get => startingPassive; private set => startingPassive = value; }
    */
    [Header("Offensive Stats")]
    [SerializeField]
    int attack;
    public int Attack { get => attack; private set => attack = value; }

    [SerializeField]
    float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; private set => projectileSpeed = value; }

    [SerializeField]
    float critDmg;
    public float CritDmg { get => critDmg; private set => critDmg = value; }

    [SerializeField]
    [Range(0f, 100f)] public float critRate;
    public float CritRate { get => critRate; private set => critRate = value; }

    [Header("Defensive Stats")]
    [SerializeField]
    public float maxHP;
    public float MaxHP { get => maxHP; private set => maxHP = value; }

    [SerializeField]
    public float armor;
    public float Armor { get => armor; private set => armor = value; }

    [SerializeField]
    [Range(0f, 1f)] public float recovery;
    public float Recovery { get => recovery; private set => recovery = value; }

    [Header("Other Stats")]
    [SerializeField]
    [Range(0f, 5f)] float pickUp;
    public float PickUp { get => pickUp; protected set => pickUp = value; }

    [SerializeField]
    [Range(0f,5f)] float movSpeed;
    public float MovSpeed { get => movSpeed; private set => movSpeed = value; }

    
}

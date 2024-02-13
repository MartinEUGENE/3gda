using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "Character/Stats")]

public class CharacterScriptable : ScriptableObject
{
    [SerializeField] 
    GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }
    
    [SerializeField]
    int maxHP;
    public int MaxHP { get => maxHP; private set => maxHP = value; }

    [SerializeField]
    float recovery;
    public float Recovery { get => recovery; private set => recovery = value; }

    [SerializeField]
    int armor;
    public int Armor { get => armor; private set => armor = value; }

    [SerializeField]
    float critRate;
    public float CritRate { get => critRate; private set => critRate = value; }

    [SerializeField]
    int critDmg;
    public int CritDmg { get => critDmg; private set => critDmg = value; }

    [SerializeField]
    int pickUp;
    public int PickUp { get => pickUp; private set => pickUp = value; }

    [SerializeField]
    float movSpeed;
    public float MovSpeed { get => movSpeed; private set => movSpeed = value; }

    [SerializeField]
    int attack;
    public int Attack { get => attack; private set => attack = value; }

    [SerializeField]
    float projectileSpeed;
    public float ProjectileSpeed { get => projectileSpeed; private set => projectileSpeed = value; }

}

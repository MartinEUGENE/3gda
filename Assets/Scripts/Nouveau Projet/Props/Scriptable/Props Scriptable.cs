using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable Objects/Prop Stats")]
public class PropsScriptable : ScriptableObject
{
    [Header("Prop Object")]
    [SerializeField]
    Sprite prop;
    public Sprite Prop { get => prop; protected set => prop = value; }

    [Header("Props HP")]
    [SerializeField]
    int hp;
    public int Hp { get => hp; protected set => hp = value; } 
}

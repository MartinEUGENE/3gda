using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Passive Items", menuName = "Scriptable Objects/Passive Item")]

public class PassiveScriptable : ScriptableObject
{
    [SerializeField]
    float multiplier; 
    public float Multiplier { get => multiplier; private set => multiplier = value; }

    [SerializeField]
    int level;
    public int Level { get => level; private set => level = value; }

    [SerializeField]
    public GameObject nextPassive; //Pas de modifs pendant le gameplay 
    public GameObject NextPassive { get => nextPassive; protected set => nextPassive = value; }

}

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

    [SerializeField]
    public Sprite icon; //Pas de modifs pendant le gameplay 
    public Sprite Icon { get => icon; protected set => icon = value; }

    [SerializeField]
    public string named; //Pas de modifs pendant le gameplay 
    public string Named { get => named; protected set => named = value; }

    [SerializeField]
    public string descrip; //Pas de modifs pendant le gameplay 
    public string Descrip { get => descrip; protected set => descrip = value; }

}

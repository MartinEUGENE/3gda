using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Passive Items", menuName = "Scriptable Objects/Passive Item")]

public class PassiveScriptable : ScriptableObject
{
    [SerializeField]
    float multiplier; 
    public float Multiplier { get => multiplier; private set => multiplier = value; }

}

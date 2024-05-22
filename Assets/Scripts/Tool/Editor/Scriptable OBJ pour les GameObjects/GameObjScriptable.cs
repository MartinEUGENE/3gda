using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Everything", menuName = "Scriptable Objects/All GameObjects")]
public class GameObjScriptable : ScriptableObject
{
    public List<GameObject> enemyGameOBJ; 
    public List<GameObject> nonEnemy; 
    public List<bool> isSpecial;
}

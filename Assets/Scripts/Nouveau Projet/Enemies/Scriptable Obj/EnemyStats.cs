using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Enemy Stats")]

public class EnemyStats : ScriptableObject
{
    [SerializeField] public float enemySpeed;
    [SerializeField] public int enemyHP;
    [SerializeField] public int enemyDmg;
}

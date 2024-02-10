using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Enemy Stats")]

public class EnemyStats : ScriptableObject
{
    [SerializeField] 
    float enemySpeed;
    public float EnemySpeed { get => enemySpeed; protected set => enemySpeed = value; }

    [SerializeField] 
    int enemyHP;
    public int EnemyHP { get => enemyHP; protected set => enemyHP = value; }

    [SerializeField] 
    int enemyDmg;
    public int EnemyDmg { get => enemyDmg; protected set => enemyDmg = value; }

}

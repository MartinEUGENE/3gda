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
    float enemyDmg;
    public float EnemyDmg { get => enemyDmg; protected set => enemyDmg = value; }

    [SerializeField]
    int damageIncreaseByLevel;
    public int DamageIncreaseByLevel { get => damageIncreaseByLevel; protected set => damageIncreaseByLevel = value; }

    [SerializeField]
    float speedIncreseByLevel;
    public float SpeedIncreseByLevel { get => speedIncreseByLevel; protected set => speedIncreseByLevel = value; }

    [SerializeField]
    int healthIncreaseByLevel;
    public int HealthIncreaseByLevel { get => healthIncreaseByLevel; protected set => healthIncreaseByLevel = value; }


}

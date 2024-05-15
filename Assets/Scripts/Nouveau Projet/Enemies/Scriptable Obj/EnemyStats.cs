using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "Scriptable Objects/Enemy Stats")]

public class EnemyStats : ScriptableObject
{
    [Header("Enemy Main Appearence")]
    
    [SerializeField]
    Sprite enemy; //Pas de modifs pendant le gameplay 
    public Sprite Enemy { get => enemy; protected set => enemy = value; }

    [SerializeField]
    bool eliteMember; 
    public bool EliteMember{ get => eliteMember; protected set => eliteMember = value; }
    
    // public EnemiesSystem system;    

    [Header("Enemy Main Stats")]
    [SerializeField] 
    [Range(0f, 2f)] float enemySpeed;
    public float EnemySpeed { get => enemySpeed; protected set => enemySpeed = value; }

    [SerializeField] 
    int enemyHP;
    public int EnemyHP { get => enemyHP; protected set => enemyHP = value; }

    [SerializeField] 
    float enemyDmg;
    public float EnemyDmg { get => enemyDmg; protected set => enemyDmg = value; }

    [SerializeField]
    float enemyTiming;
    public float EnemyTiming { get => enemyTiming; protected set => enemyTiming = value; }

    
    [Header("Increase by Level")]

    [SerializeField]
    [Range(0, 25)] int damageIncreaseByLevel;
    public int DamageIncreaseByLevel { get => damageIncreaseByLevel; protected set => damageIncreaseByLevel = value; }

    [SerializeField]
    [Range(0f, .05f)] float speedIncreseByLevel;
    public float SpeedIncreseByLevel { get => speedIncreseByLevel; protected set => speedIncreseByLevel = value; }

    [SerializeField]
    [Range(0,15)]int healthIncreaseByLevel;
    public int HealthIncreaseByLevel { get => healthIncreaseByLevel; protected set => healthIncreaseByLevel = value; }
    
    [Header("Prefab des obj")]
    [SerializeField]
    GameObject currentEnemyObj;
    public GameObject CurrentEnemyObj { get => currentEnemyObj; protected set => currentEnemyObj = value; }

    [SerializeField]
    GameObject replacement;
    public GameObject Replacement { get => replacement; protected set => replacement = value; }
}

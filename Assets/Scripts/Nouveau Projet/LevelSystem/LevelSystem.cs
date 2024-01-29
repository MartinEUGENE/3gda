using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] int experience = 0; 
    [SerializeField] int level = 1; 

    public virtual void CurrentLevel()
    {

    }

    public virtual void LevelUpPlayer()
    {

    }

    public virtual void LevelUpEnemy()
    {

    }
}

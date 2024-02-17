using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public List<EnemyGroup> enemyGroups; 
        public string waveName;
        public int waveCount; //nombre d'ennemis total dans la wave
        public float spawnInterv; //float qui sert d'intervalle entre chaque spawn
        public int spawnCount; //comptage d'ennemis
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public string enemyName; //nom de l'ennemi
        public int enemyCount; //Nombre d'ennemi de ce type en particulier
        public GameObject enemyPrefab; // de l'ennemi
        public int spawnCount; //comptage d'ennemis
    }

    public List<Wave> waves; //Toutes les vagues dans le jeu.
    public int currentWaveCount; //numéro de la vague de base qui commence à 0 
    Transform player;

    ///public GameObject spawnPoint;

    [Header("Timer")]
    float timerSpawn; 

    public float waveInterval;

    [Header("Enemy count")]
    public int enemyAllowed;
    public int enemyAlive;
    public bool maxEnemy = false; 

    public void Start()
    {
        player = FindObjectOfType<CharacterStats>().transform;
        CalculateWaveQuota();
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuote = 0; 
        foreach( var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuote += enemyGroup.enemyCount; 
        }

        waves[currentWaveCount].waveCount = currentWaveQuote;
        Debug.LogWarning(currentWaveQuote);
    }

    public void Update()
    {
        if(currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0)
        {
           // Debug.Log("Begin the next wave bro !");
            StartCoroutine(NextWave());
        }

        timerSpawn += Time.deltaTime; 
        if(timerSpawn >= waves[currentWaveCount].spawnInterv)
        {
            timerSpawn = 0f;
            SpawnEnemy();
        }
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(waveInterval);
        if(currentWaveCount < waves.Count -1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }

    public void SpawnEnemy()
    {
        //Vérifie si le minimum du nombre des ennemis a été invoqué. 
       if(waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveCount && !maxEnemy)
       {
            //tant que le quota d'ennemi n'est pas atteint, les ennemis vont spawner
            foreach(var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                //Check si le nombre d'ennemi d'un type minimal a été invoqué
                if(enemyGroup.enemyCount > enemyGroup.spawnCount)
                {
                    if (enemyAlive >= enemyAllowed)
                    {
                        maxEnemy = true;
                        return;
                    }

                    Vector2 spawnPoint = new Vector2(player.transform.position.x + Random.Range(-15f, 15f), player.transform.position.y + Random.Range(-15f,15f));
                    Instantiate(enemyGroup.enemyPrefab, spawnPoint, Quaternion.identity);
                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemyAlive++; //ajoute 1 au compte d'ennemis vivants dans le niveau. 
                }
            }
       }

        if (enemyAlive < enemyAllowed)
        {
            maxEnemy = false; // passe ce bool en faux et permet de recommencer le spawn d'ennemi
        }

    }

    public void EnemyKill()
    {
        enemyAlive--; //si un ennemi a été tué, on retire 1 ici. 
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEliteMember : MonoBehaviour
{
    public GameObject[] eliteTrace;
    public GameObject[] bossTrace;

    public int playerLvl = 0;
    CharacterStats player;

    private void Start()
    {
        player = FindObjectOfType<CharacterStats>(); 
    }

    private void Update()
    {
        playerLvl = player.level; 

        if(playerLvl == 5 || playerLvl == 10 || playerLvl == 20 || playerLvl == 25 || playerLvl == 35 || playerLvl == 40)
        {
            Instantiate(eliteTrace[Random.Range(0, eliteTrace.Length)], transform.position, Quaternion.identity);
        }

        else if(playerLvl == 15 || playerLvl == 30 || playerLvl == 45)
        {
            Instantiate(bossTrace[Random.Range(0, bossTrace.Length)], transform.position, Quaternion.identity);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEliteMember : MonoBehaviour
{
    public GameObject[] eliteTrace;
    public GameObject[] bossTrace;

    public int playerLvl = 0;
    public float invocationNumber = 10f ;
    CharacterStats player;

    private void Start()
    {
        player = FindObjectOfType<CharacterStats>(); 
    }

    private void Update()
    {
        playerLvl = player.level;
        invocationNumber -= Time.deltaTime; 
        if(invocationNumber<=0f)
        {
            SpawnPlease();
            invocationNumber += 20f; 
        }
    }

    void SpawnPlease()
    {

        if (playerLvl == 5 || playerLvl == 10 || playerLvl == 20)
        {
            Instantiate(eliteTrace[Random.Range(0, eliteTrace.Length)], transform.position, Quaternion.identity);
        }

        else if (playerLvl == 15 || playerLvl == 30 || playerLvl == 45)
        {
            Instantiate(bossTrace[Random.Range(0, bossTrace.Length)], transform.position + player.transform.position, Quaternion.identity);
        }
    }

}

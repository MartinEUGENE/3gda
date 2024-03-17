using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControler : MonoBehaviour
{
    public List<GameObject> tChunks;
    public GameObject player;
    public float radiusChecker;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    CharactControls cc;

    [Header("Opti")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDistance; // must be greater than lenght and width of tilemap
    float opDistance;
    float optiCooldown;
    public float cooldonwDuration;

    void Start()
    {
        cc = FindObjectOfType<CharactControls>();
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker();
        ChunkOpti();
    }

    void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }

        if(cc.moving.x > 0 && cc.moving.y == 0) //right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("right").position, radiusChecker, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("right").position;
                SpawnChunk();
            }
        }
        else if (cc.moving.x < 0 && cc.moving.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("left").position, radiusChecker, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("left").position;
                SpawnChunk();
            }
        }
        else if (cc.moving.x == 0 && cc.moving.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("up").position, radiusChecker, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("up").position;
                SpawnChunk();
            }
        }
        else if (cc.moving.x == 0 && cc.moving.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("down").position, radiusChecker, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("down").position;
                SpawnChunk();
            }
        }
        else if (cc.moving.x > 0 && cc.moving.y > 0) //right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("up right").position, radiusChecker, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("up right").position;
                SpawnChunk();
            }
        }
        else if (cc.moving.x > 0 && cc.moving.y < 0) //right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("down right").position, radiusChecker, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("down right").position;
                SpawnChunk();
            }
        }
        else if (cc.moving.x < 0 && cc.moving.y > 0) //left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("up left").position, radiusChecker, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("up left").position;
                SpawnChunk();
            }
        }
        else if (cc.moving.x < 0 && cc.moving.y < 0) //left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("down left").position, radiusChecker, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("down left").position;
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, tChunks.Count);
        latestChunk = Instantiate(tChunks[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    void ChunkOpti()
    {
        optiCooldown -= Time.deltaTime;

        if(optiCooldown <= 0f)
        {
            optiCooldown = cooldonwDuration;
        }
        else
        { 
           return;
        } 

        foreach(GameObject chunk in spawnedChunks)
        {
            opDistance = Vector3.Distance(player.transform.position, chunk.transform.position);
            if(opDistance > maxOpDistance)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}

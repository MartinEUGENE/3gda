using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControler : MonoBehaviour
{
    public List<GameObject> tChunks;
    public GameObject player;
    public float radiusChecker;

    public LayerMask terrainMask;
    public GameObject currentChunk;
    Vector3 lastPosition;

    [Header("Opti")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDistance; // must be greater than lenght and width of tilemap
    float opDistance;
    float optiCooldown;
    public float cooldonwDuration;

    void Start()
    {
        lastPosition = player.transform.position;
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

        Vector3 moveDir = player.transform.position - lastPosition;
        lastPosition = player.transform.position;

        string directionName = GetDirection(moveDir);

        CheckAndSpawn(directionName);

        if (directionName.Contains("up"))
        {
            CheckAndSpawn("up");
        }
        if (directionName.Contains("down"))
        {
            CheckAndSpawn("down");
        }
        if (directionName.Contains("left"))
        {
            CheckAndSpawn("left");
        }
        if (directionName.Contains("right"))
        {
            CheckAndSpawn("right");
        }
    }

    void CheckAndSpawn(string direction)
    {
        if (!Physics2D.OverlapCircle(currentChunk.transform.Find(direction).position, radiusChecker, terrainMask))
        {
            SpawnChunk(currentChunk.transform.Find(direction).position);
        }
    }

    string GetDirection(Vector3 direction)
    {
        direction = direction.normalized;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.y > 0.5f)
            {
                return direction.x > 0 ? "up right" : "up left";
            }
            else if (direction.y < -0.5f)
            {
                return direction.x > 0 ? "down right" : "down left";
            }
            else 
            { 
               return direction.x > 0 ? "right" : "left"; 
            }
        }
        else
        {
            if (direction.x > 0.5f)
            {
                return direction.y > 0 ? "up right" : "down right";
            }
            else if (direction.x > -0.5f)
            {
                return direction.y > 0 ? "up left" : "down left";
            }
            else 
            { 
                return direction.y > 0 ? "up" : "down"; 
            }
        }
    }

    void SpawnChunk(Vector3 spawnPosition)
    {
        int rand = Random.Range(0, tChunks.Count);
        latestChunk = Instantiate(tChunks[rand], spawnPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    void ChunkOpti()
    {
        optiCooldown -= Time.deltaTime;

        if (optiCooldown <= 0f)
        {
            optiCooldown = cooldonwDuration;
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in spawnedChunks)
        {
            opDistance = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDistance > maxOpDistance)
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

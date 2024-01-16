using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] Transform[] teleporters; 
    
    void Start()
    {
        if (teleporters.Length != 6)
        {
            Debug.LogError("Please assign exactly 7 teleport points in the inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i <= 6; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                TeleportPlayer(i - 1);
            }
        }
    }

    void TeleportPlayer(int index)
    {
        if (index >= 0 && index < teleporters.Length)
        {
            transform.position = teleporters[index].position;
        }
        else
        {
            Debug.LogError("Invalid teleport index.");
        }

    }
}

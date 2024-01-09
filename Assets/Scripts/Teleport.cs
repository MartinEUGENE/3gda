using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform[] teleportPoints;

    private void Start()
    {
        if (teleportPoints.Length != 7)
        {
            Debug.LogError("Please assign exactly 7 teleport points in the inspector.");
        }
    }

    private void Update()
    {
        for (int i = 1; i <= 7; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                TeleportPlayer(i - 1);
            }
        }
    }

    void TeleportPlayer(int index)
    {
        if (index >= 0 && index < teleportPoints.Length)
        {
            transform.position = teleportPoints[index].position;
        }
        else
        {
            Debug.LogError("Invalid teleport index.");
        }
    }
}

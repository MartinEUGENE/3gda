using System.Collections;
using UnityEngine;

public class Editor : MonoBehaviour
{
    public GameObject[] stock;
    public GameObject essayer;
    public int objetActif;

    void Update()
    {
        // Increase or decrease objetActif based on the scroll wheel movement
        objetActif += (int)Input.mouseScrollDelta.y;

        // Ensure objetActif stays within the valid range
        objetActif = Mathf.Clamp(objetActif, 0, stock.Length - 1);

        if (Input.GetMouseButtonDown(1))
        {
            objetActif = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                SpawnPrefab(hit.point);
            }
        }
    }

    void SpawnPrefab(Vector3 position)
    {
        if (objetActif >= 0 && objetActif < stock.Length)
        {
            Instantiate(stock[objetActif], position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Invalid objetActif index.");
        }
    }
}

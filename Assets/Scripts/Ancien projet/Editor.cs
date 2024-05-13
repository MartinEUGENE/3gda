using System.Collections;
using UnityEngine;

public class Editor : MonoBehaviour
{
    public GameObject[] stock;
    public GameObject essayer;
    public int objetActif;
    public bool editOn = false;
    public Camera camPlay;
    public Camera camBuild;

    void Start()
    {
        
        camPlay.enabled = true;
        camBuild.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            editOn = !editOn;
        }

        Switch();

        objetActif += (int)Input.mouseScrollDelta.y;
        
        objetActif = Mathf.Clamp(objetActif, 0, stock.Length - 1);

        if(editOn == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                objetActif = 0;
            }

            if (Input.GetMouseButtonDown(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    SpawnPrefab(hit.point);
                }
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

    public void Switch()
    {
        if( editOn == true)
        {
            camPlay.enabled = false;
            camBuild.enabled = true;
        }
        else
        {
            // Switch back to the first camera
            camPlay.enabled = true;
            camBuild.enabled = false;
        }
    }
}

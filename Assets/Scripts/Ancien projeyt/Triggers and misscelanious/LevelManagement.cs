using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManagement : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject crossair;
    [SerializeField] string CurrentScene;

    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(CurrentScene);
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(CurrentScene);
    }

    public void ButtonStart()
    {
        crossair.SetActive(false);
        button.SetActive(true);
    }
}

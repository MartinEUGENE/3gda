using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public MenuMusicController menu;

    private void Start()
    {
        menu = FindObjectOfType<MenuMusicController>(); 
    }
    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1f; 

        if(name !="ChoosingScene")
        {
            menu.menuMuse.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); 
        }
    }

    public void CloseScene()
    {
        Application.Quit(); 
    }
}

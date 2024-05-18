using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusicController : MonoBehaviour
{

    public FMOD.Studio.EventInstance menuMuse;
    public int para = 0; 

    void Start()
    {
        menuMuse = FMODUnity.RuntimeManager.CreateInstance("event:/New Project/Music/Menu_Music");
        menuMuse.start(); 
    }

    public void SwitchParameter()
    {
        if(para == 0)
        {
            para++;
            menuMuse.setParameterByName("Choosing Character", para); 
        }
        else if (para == 1)
        {
            para--;
            menuMuse.setParameterByName("Choosing Character", para);
        }

    }
}

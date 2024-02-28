using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instance;
    public CharacterScriptable charaData;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("EXTRA" + instance +"Deleted"); 
            Destroy(gameObject);
        }
    }

    public static CharacterScriptable GetData()
    {
        return instance.charaData; 
    }

    public void SelectCharacter(CharacterScriptable character)
    {
        charaData = character;
    }

}

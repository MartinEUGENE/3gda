using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelEditorWindow : EditorWindow
{
    [MenuItem("Tools/Level Management/Management")]
    /*public static void ShowWindow()
    {
        var window = GetWindow<LevelEditorWindow>();
        window.titleContent = new GUIContent("Level Manager");
        window.Show();
    }

    Vector2 scroll;
    Texture2D sprite;


    private void OnGUI()
    {*//*
        LoadAllAssetsOfType<GameObjScriptable>(out GameObjScriptable[] gaming);

        if (gaming.Length != 0)
        {
            GUILayout.BeginHorizontal();
            for(int i = 0; i < gaming.Length; i++)
            {

            }

            GUILayout.EndHorizontal();
        }*//*
    }
*/
   /* private void LoadAllAssetsOfType<T>(out T[] assets) where T : Object
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T));
        assets = new T[guids.Length];

        for (int i = 0; i < guids.Length; i++)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
            assets[i] = AssetDatabase.LoadAssetAtPath<T>(assetPath);
        }
    }*/


    void GameObjClassification(GameObject obj)
    {

    }

}

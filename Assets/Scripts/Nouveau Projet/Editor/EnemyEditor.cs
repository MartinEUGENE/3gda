using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class EnemyEditor : EditorWindow
{
    [MenuItem("Tools/Enemy Management/Enemy Creator Window")]
    public static void ShowWindow()
    {
        var window = GetWindow<EnemyEditor>();
        window.titleContent = new GUIContent("Enemy Manager");
        window.Show();
    }

    Vector2 scroll; 

    private void OnGUI()
    {
        //LoadAllAssetsOfType<EnemyStats>(out EnemyStats[] enemyStats);
        GUI.backgroundColor = new Color(0.8f, .2f, 1f);
        GUIStyle style = new GUIStyle();
        
       
        GUILayout.BeginVertical();
        scroll = GUILayout.BeginScrollView(scroll);

        GUILayout.EndScrollView();
        GUILayout.EndVertical();
    }

    

    private void LoadAllAssetsOfType<T>(out T[] assets) where T : Object
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T));
        assets = new T[guids.Length];

        for (int i = 0; i < guids.Length; i++)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
            assets[i] = AssetDatabase.LoadAssetAtPath<T>(assetPath);
        }
    }
}

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
    Texture2D sprite; 

    private void OnGUI()
    {
        LoadAllAssetsOfType <EnemyStats>(out EnemyStats[] enemies);
        GUI.backgroundColor = new Color(0.8f, .2f, 1f);

        if (enemies.Length == 0)
        {
            EditorGUILayout.LabelField("We finally banned weapons from the whole world, we can have peace now !");
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginScrollView(scroll); 

        foreach(EnemyStats en in enemies)
        {
            EditorGUILayout.BeginVertical();

            SerializedObject ai = new SerializedObject(en);
            ai.Update();

            SerializedProperty ichi = ai.FindProperty("enemy");
            EditorGUILayout.PropertyField(ichi);

            SerializedProperty ni = ai.FindProperty("enemyHP"); 
            EditorGUILayout.PropertyField(ni);

            SerializedProperty san = ai.FindProperty("enemyDmg");
            EditorGUILayout.PropertyField(san);

            SerializedProperty chi = ai.FindProperty("enemyTiming");
            EditorGUILayout.PropertyField(chi);

            SerializedProperty go = ai.FindProperty("enemySpeed");
            EditorGUILayout.PropertyField(go);

            SerializedProperty roku = ai.FindProperty("damageIncreaseByLevel");
            EditorGUILayout.PropertyField(roku);

            SerializedProperty nana = ai.FindProperty("speedIncreseByLevel");
            EditorGUILayout.PropertyField(nana);

            SerializedProperty hachi = ai.FindProperty("healthIncreaseByLevel");
            EditorGUILayout.PropertyField(hachi);


            ai.ApplyModifiedProperties();
            
            EditorGUILayout.EndVertical(); 
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();

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

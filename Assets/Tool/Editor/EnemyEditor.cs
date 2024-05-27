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

        window.maxSize = new Vector2 (1920, 720);
        window.minSize = new Vector2 (450, 200); 
    }

    Vector2 scroll;
    Texture2D sprite;

    EnemyStats theEnemy;
    GameObject group;

    string typedResult;
    string typeResult;
    [Range(1,4)] int chooseEnemyType;

    private void OnGUI()
    {
        GUI.backgroundColor = new Color(0.8f, .2f, 1f);
        LoadAllAssetsOfType<EnemyStats>(out EnemyStats[] enemies);

        if (enemies.Length == 0)
        {
            EditorGUILayout.LabelField("I have no enenmy.");
        }

        EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
        EditorGUILayout.BeginScrollView(scroll);

        GUILayout.Box("Enemy Creator Manager", GUILayout.ExpandWidth(true), GUILayout.Height(30));
        foreach (EnemyStats en in enemies)
        {
            EditorGUILayout.BeginHorizontal();
            SerializedObject ai = new SerializedObject(en);
            ai.Update();

            if (GUILayout.Button(text: en.ToString()))
            {               
                theEnemy = en;
            }

            ai.ApplyModifiedProperties();           
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.Space(30);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Box("New Scriptable Creation", GUILayout.ExpandWidth(true), GUILayout.Height(18.5f));
        typedResult = EditorGUILayout.TextArea(typedResult, GUILayout.Width(150));
        if (GUILayout.Button(text: "New Enemy Stats", GUILayout.Width(150)))
        {
            CreateStats();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(20);

        EditorGUILayout.BeginVertical(); 
        if (theEnemy != null)
        {            
            SerializedObject so = new SerializedObject(theEnemy);
            so.Update();

            SerializedProperty ichi = so.FindProperty("enemy");
            GUILayout.BeginHorizontal(); 
            EditorGUILayout.PropertyField(ichi, GUIContent.none);
            Sprite sprite = (Sprite)ichi.objectReferenceValue;
            if (sprite != null)
            {
                GUILayout.Box(sprite.texture, GUILayout.Height(80), GUILayout.Width(80));
            }
            GUILayout.EndHorizontal(); 

            SerializedProperty dos = so.FindProperty("eliteMember");
            EditorGUILayout.PropertyField(dos);

            SerializedProperty di = so.FindProperty("enemyType");
            EditorGUILayout.PropertyField(di);

            SerializedProperty ni = so.FindProperty("enemyHP");
            EditorGUILayout.PropertyField(ni);

            SerializedProperty san = so.FindProperty("enemyDmg");
            EditorGUILayout.PropertyField(san);

            SerializedProperty chi = so.FindProperty("enemyTiming");
            EditorGUILayout.PropertyField(chi);

            SerializedProperty go = so.FindProperty("enemySpeed");
            EditorGUILayout.PropertyField(go);
            
            SerializedProperty roku = so.FindProperty("damageIncreaseByLevel");
            EditorGUILayout.PropertyField(roku);

            SerializedProperty nana = so.FindProperty("speedIncreseByLevel");
            EditorGUILayout.PropertyField(nana);

            SerializedProperty hachi = so.FindProperty("healthIncreaseByLevel");
            EditorGUILayout.PropertyField(hachi);

            so.ApplyModifiedProperties();
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space(35);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Box("New GameObject Creation", GUILayout.ExpandWidth(true), GUILayout.Height(18.5f));
        chooseEnemyType = EditorGUILayout.IntField(chooseEnemyType, GUILayout.Width(150));
        if(GUILayout.Button(text: "New Enemy Object", GUILayout.Width(150)))
        {
            switch(chooseEnemyType)
            {
                default:
                    CreateAnEnemy();
                    break;
            }
        }
        EditorGUILayout.EndHorizontal(); 
        
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();
    }

    void CreateStats()
    {
        theEnemy = new EnemyStats();
        AssetDatabase.CreateAsset(theEnemy, "Assets/Scripts/Nouveau Projet/Enemies/Scriptable Obj/" + typedResult + ".asset");
    } 
    //ici je vais faire la fonction pour la creation d'un gameObject 
    //Je n'ai pas vu de méthode qui me permettrait de transformer un gameObject en Prefab immédiatement après sa création.
    void CreateAnEnemy()
    {
        group = new GameObject();
        group.tag = "Enemy";
        group.layer = 9; 

        //Ajout forcé de tous les composants dont j'ai besoin sur le gameObject, je n'ai pas trouvé d'autres façons de faire cet ajout mieux
        group.AddComponent<Rigidbody2D>();
        group.AddComponent<SpriteRenderer>(); 
        group.AddComponent<PolygonCollider2D>(); 
        group.AddComponent<DropRateManager>(); 

        group.GetComponent<SpriteRenderer>().sprite = theEnemy.Enemy; 

        switch(chooseEnemyType)
        {
            case 1:
                group.AddComponent<EnemiesSystem>();
                group.GetComponent<EnemiesSystem>().stats = theEnemy;
                Debug.LogError("A Chicken was created");
                //Le Log Error est mis exprès ici pour forcer les autres designers à regarder la console lors de la création de l'objet.  

                break;
            case 2:
                group.AddComponent<TurretEnemy>();
                group.GetComponent<TurretEnemy>().stats = theEnemy;
                Debug.LogError("A Turret was created");

                break;          
            case 3:
                group.AddComponent<RushingEnemy>();
                group.GetComponent<RushingEnemy>().stats = theEnemy;
                Debug.LogError("A Rusher was created");

                break;            
            case 4:
                group.AddComponent<HordeEnemies>();
                group.GetComponent<HordeEnemies>().stats = theEnemy;
                Debug.LogError("A Horde was created"); 
                break;
        }
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



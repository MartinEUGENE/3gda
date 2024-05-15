using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine;
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
    GameObject anEnemy;

    GameObject[] group;

    string typedResult;

    /*private void CreateGUI()
    {
        var splitView = new TwoPaneSplitView(0, 250, TwoPaneSplitViewOrientation.Horizontal);
        LoadAllAssetsOfType<EnemyStats>(out EnemyStats[] enemies);
        rootVisualElement.Add(splitView);

        var leftPane = new ListView();
        splitView.Add(leftPane);
        rightPlane = new ScrollView(ScrollViewMode.VerticalAndHorizontal);
        splitView.Add(rightPlane);

        leftPane.makeItem = () => new Label();
        leftPane.bindItem = (item, index) => { (item as Label).text = enemies[index].name;};
        leftPane.itemsSource = enemies;

        leftPane.onSelectionChange += OnSpriteSelectionChange;
        leftPane.selectedIndex = m_SelectedIndex;

        leftPane.onSelectionChange += (items) => { m_SelectedIndex = leftPane.selectedIndex; };
    }*/


    private void OnGUI()
    {
        GUI.backgroundColor = new Color(0.8f, .2f, 1f);
        LoadAllAssetsOfType<EnemyStats>(out EnemyStats[] enemies);


        if (enemies.Length == 0)
        {
            EditorGUILayout.LabelField("I have no enenmies.");
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginScrollView(scroll);

        GUILayout.Box("Enemy Creator Manager", GUILayout.ExpandWidth(true), GUILayout.Height(30));
        foreach (EnemyStats en in enemies)
        {
            EditorGUILayout.BeginVertical();
            SerializedObject ai = new SerializedObject(en);
            ai.Update();

            if (GUILayout.Button(text: en.ToString()))
            {               
                theEnemy = en;
            }

            ai.ApplyModifiedProperties();           
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.Space(30);

        EditorGUILayout.BeginVertical(); 
        if (theEnemy != null)
        {
            SerializedObject so = new SerializedObject(theEnemy);
            so.Update();

            SerializedProperty ichi = so.FindProperty("enemy");
            EditorGUILayout.PropertyField(ichi);

            SerializedProperty dos = so.FindProperty("eliteMember");
            EditorGUILayout.PropertyField(dos);   

            if(dos.boolValue == true)
            {

            }
            
            /*SerializedProperty tres = so.FindProperty("system");
            EditorGUILayout.PropertyField(tres);*/

            SerializedProperty ni = so.FindProperty("enemyHP");
            EditorGUILayout.PropertyField(ni);

            SerializedProperty san = so.FindProperty("enemyDmg");
            EditorGUILayout.PropertyField(san);

            SerializedProperty chi = so.FindProperty("enemyTiming");
            EditorGUILayout.PropertyField(chi);

            SerializedProperty go = so.FindProperty("enemySpeed");
            EditorGUILayout.PropertyField(go);
            
            SerializedProperty ku = so.FindProperty("enemyXpValue");
            EditorGUILayout.PropertyField(ku);
            
            SerializedProperty roku = so.FindProperty("damageIncreaseByLevel");
            EditorGUILayout.PropertyField(roku);

            SerializedProperty nana = so.FindProperty("speedIncreseByLevel");
            EditorGUILayout.PropertyField(nana);

            SerializedProperty hachi = so.FindProperty("healthIncreaseByLevel");
            EditorGUILayout.PropertyField(hachi);

            SerializedProperty nu = so.FindProperty("xpIncrease");
            EditorGUILayout.PropertyField(nu);

            so.ApplyModifiedProperties();
        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.Space(70);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Box("New Scriptable Creation", GUILayout.ExpandWidth(true), GUILayout.Height(18.5f));
        typedResult = EditorGUILayout.TextArea(typedResult, GUILayout.Width(150));
        if (GUILayout.Button(text: "New Enemy Type", GUILayout.Width(150)))
        {
            CreateStats();
        }
        EditorGUILayout.EndHorizontal();


        /*foreach(GameObject ga in group)
        {

        }*/

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();
    }

    void CreateStats()
    {
        theEnemy = new EnemyStats();
        AssetDatabase.CreateAsset(theEnemy, "Assets/Scripts/Nouveau Projet/Enemies/Scriptable Obj/" + typedResult + ".asset");
    } 

    //ici je vais faire la fonction pour la creation d'un asset de type prefab qui prendra en compte les scripts EnemiesSystem et le 
    void CreateAnEnemy()
    {
        AssetDatabase.CreateAsset(anEnemy, "Assets/Prefab/NewProject/Enemies/" + typedResult + ".prefab");
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

/*void OnSpriteSelectionChange(IEnumerable<object> selectedItems)
 {
     rightPlane.Clear();

     var enumerator = selectedItems.GetEnumerator();
     if (enumerator.MoveNext())
     {
         var selectedStats = enumerator.Current as EnemyStats;
         if (selectedStats != null)
         {
            theEnemy = selectedStats; 
         }
     }

 }*/


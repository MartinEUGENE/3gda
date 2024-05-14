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
    string typedResult;
    
    [SerializeField] private int m_SelectedIndex = -1;
    private VisualElement rightPlane;

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

        //sprite. = AssetDatabase.FindAssets("Assets/ah.png");   

        if (enemies.Length == 0)
        {
            EditorGUILayout.LabelField("I have no enenmies.");
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginScrollView(scroll);

        foreach (EnemyStats en in enemies)
        {
            EditorGUILayout.BeginVertical(GUILayout.Width(300));
            SerializedObject ai = new SerializedObject(en);
            ai.Update();

            if (GUILayout.Button(text: en.ToString()))
            {
               EditorGUILayout.BeginHorizontal();
                //theEnemy = ScriptableObject.CreateInstance(en.ToString()); 
                theEnemy = en; 
                if(theEnemy !=null)
                {
                    EditorGUILayout.PropertyField(ai.FindProperty("enemy"));
                    EditorGUILayout.PropertyField(ai.FindProperty("enemyHP"));
                    EditorGUILayout.PropertyField(ai.FindProperty("enemyDmg"));
                    EditorGUILayout.PropertyField(ai.FindProperty("enemyTiming"));
                    EditorGUILayout.PropertyField(ai.FindProperty("enemySpeed"));

                    EditorGUILayout.PropertyField(ai.FindProperty("damageIncreaseByLevel"));
                    EditorGUILayout.PropertyField(ai.FindProperty("speedIncreseByLevel"));
                    EditorGUILayout.PropertyField(ai.FindProperty("healthIncreaseByLevel"));
                }

                EditorGUILayout.EndHorizontal();
            }

            ai.ApplyModifiedProperties();
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.BeginHorizontal(GUILayout.Width(300));
        typedResult = EditorGUILayout.TextArea(typedResult, GUILayout.Width(150));
        if (GUILayout.Button(text: "New Enemy Type", GUILayout.Width(150)))
        {
            CreateTheEnemy();
        }

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();
    }

    void OpenTheEnemy(EnemyStats enemy)
    {
        theEnemy = enemy;
    }

    void CreateTheEnemy()
    {
        theEnemy = new EnemyStats();
        AssetDatabase.CreateAsset(theEnemy, typedResult);
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


/*private void OnGUI()
    {
        GUI.backgroundColor = new Color(0.8f, .2f, 1f);
        LoadAllAssetsOfType<EnemyStats>(out EnemyStats[] enemies);

        //sprite. = AssetDatabase.FindAssets("Assets/ah.png");   

        if (enemies.Length == 0)
        {
            EditorGUILayout.LabelField("I have no enenmies.");
        }

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginScrollView(scroll);

        foreach (EnemyStats en in enemies)
        {
            EditorGUILayout.BeginVertical(GUILayout.Width(300));
            SerializedObject ai = new SerializedObject(en);
            ai.Update();

            if (GUILayout.Button(text: en.ToString()))
            {
                EditorGUILayout.BeginHorizontal();
                OpenTheEnemy(en);

                EditorGUILayout.EndHorizontal();
            }

            ai.ApplyModifiedProperties();
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.BeginHorizontal(GUILayout.Width(300));

        typedResult = EditorGUILayout.TextArea(typedResult);
        if (GUILayout.Button(text: "Create New Enemy Type"))
        {
            CreateTheEnemy();
        }

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndScrollView();
    }

    void OpenTheEnemy(EnemyStats enemy)
    {
        theEnemy = enemy;         
    }

    void CreateTheEnemy()
    {
        theEnemy = new EnemyStats();
        AssetDatabase.CreateAsset(theEnemy, typedResult); 
    }

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
EditorGUILayout.PropertyField(hachi);*/

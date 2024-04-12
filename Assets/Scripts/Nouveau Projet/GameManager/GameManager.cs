using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //un des diff�rents �tats du jeu cr��s avec un enum
    public enum GameState
    {
        Gameplay,
        Pause,
        GameOver,
        LevelUp
    }

    [Header("Pause Screen")]
    public GameObject pauseScreen;

    [Header("Results Screen")]
    public GameObject resultScreen;

    [Header("Level Up Screen")]
    public GameObject levelUpScreen;
    [Header("Ingame UI")]
    public GameObject inGameUI; 

    [Header("Damage Colors and GameStates")]
    public GameState currentState;
    //�tat du jeu avant l'�tat actuel
    public GameState previousState;

    public Color healChara;
    public Color normalDmg;
    public Color critDmg;
    public Color playerDmg;

    [Header("Damage Text Settings")]
    public Canvas damageTextCanvas;
    public float textFontSize = 20;
    public TMP_FontAsset textFont;
    public Camera referenceCamera;


    public bool isGameOver = false;
    public bool isChoosingUpgrade = false;

    public GameObject playerObj;

    public int[] randomIndexes = new int[3];

    private void Awake()
    {
        DisableScreens();
        playerObj = FindObjectOfType<CharacterStats>().gameObject;
        instance = this;
        for (int i = 0; i < randomIndexes.Length; i++)
        {
            randomIndexes[i] = Random.Range(0, 3);
        }
    }

    void Update()
    {
        //on compare chacune des valeurs 
        switch (currentState)
        {
            case GameState.Gameplay:
                //Code � mettre pour la case de l'�tat de jeu ici.
                CheckPauseResume();
                break;

            case GameState.Pause:
                //Code � mettre pour la case de l'�tat de jeu ici.
                if(Input.GetKey(KeyCode.Escape))
                {
                    PauseGame(); 
                }
                
                break;

            case GameState.GameOver:

                if (!isGameOver)
                {
                    isGameOver = true;
                    Time.timeScale = 0f;
                    DisplayResults();
                }

                break;

            case GameState.LevelUp:

                if (!isChoosingUpgrade)
                {
                    isChoosingUpgrade = true;
                    Time.timeScale = 0f;
                    levelUpScreen.SetActive(true);
                    playerObj.GetComponent<InventoryManager>().Upgrading(randomIndexes);
                }

                break;

            //Ligne pour g�rer dans un cas o� on se retrouve sur le mauvais gamestate.
            default:
                Debug.LogWarning("This GameState does not exist, why are you here ?");
                break;
        }

        if (randomIndexes[1] == randomIndexes[0])
        {
            randomIndexes[1] = Random.Range(0, 3);
        }
        else if (randomIndexes[2] == randomIndexes[0 | 1])
        {
            randomIndexes[2] = Random.Range(0, 3);
        }
    }

    IEnumerator GenerateFloatingTextCoroutine(string text, Transform target, float duration = 1f, float speed = 10f, bool crit = true, bool heal = true, bool chara = false)
    {
        GameObject textObj = new GameObject("Damage Floating Text");
        textObj.AddComponent<CanvasGroup>();
        CanvasGroup alpha = textObj.GetComponent<CanvasGroup>();
        RectTransform rect = textObj.AddComponent<RectTransform>();
        TextMeshProUGUI tmPro = textObj.AddComponent<TextMeshProUGUI>();
        tmPro.text = text;
        tmPro.horizontalAlignment = HorizontalAlignmentOptions.Center;
        tmPro.verticalAlignment = VerticalAlignmentOptions.Middle;
        tmPro.fontSize = textFontSize;
        if (textFont) tmPro.font = textFont;
        rect.position = referenceCamera.WorldToScreenPoint(target.position);

        Destroy(textObj, duration);

        textObj.transform.SetParent(instance.damageTextCanvas.transform);

        WaitForEndOfFrame w = new WaitForEndOfFrame();
        float t = 0;
        float yOffset = 0;

        while (t < duration)// la couleurs change selon l'arme
        {
            //Debug.Log(t);
            yield return w;
            t += Time.deltaTime;

            if (crit)
            {
                textObj.GetComponent<TextMeshProUGUI>().color = critDmg;
            }
            else if (heal)
            {
                textObj.GetComponent<TextMeshProUGUI>().color = healChara;
            }
            else if (chara)
            {
                textObj.GetComponent<TextMeshProUGUI>().color = playerDmg;
            }

            else
            {
                textObj.GetComponent<TextMeshProUGUI>().color = normalDmg;
            }

            //Debug.Log("re");
            if (t > 0.2)
            {
                yOffset += speed * Time.deltaTime;
                //rect.position = referenceCamera.WorldToScreenPoint(target.position + new Vector3(0, yOffset));
                rect.position = rect.position + new Vector3(0, yOffset);
                //Debug.Log("done");
                alpha.alpha -= Time.deltaTime;
                tmPro.fontSize = tmPro.fontSize - 10f * Time.deltaTime;
            }

        }
    }
    public static void GenerateFloatingText(string text, Transform target, float duration = 1f, float speed = 1.25f, bool crit = true, bool heal = true, bool chara = false)
    {
        // if canvas not set, end the function so we don't generate any floating text
        if (instance.damageTextCanvas == null)
        {
            return;
        }

        if (!instance.referenceCamera)
        {
            instance.referenceCamera = Camera.main;

        }

        bool Crit = crit;
        bool Heal = heal;
        bool Chara = chara;

        instance.StartCoroutine(instance.GenerateFloatingTextCoroutine(text, target, duration, speed, Crit, Heal, Chara));
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    public void PauseGame()
    {
        if (currentState != GameState.Pause)
        {
            previousState = currentState;
            ChangeState(GameState.Pause);
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        if (currentState == GameState.Pause)
        {
            ChangeState(previousState);
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    void CheckPauseResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Pause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    void DisableScreens()
    {
        pauseScreen.SetActive(false);
        resultScreen.SetActive(false);
        levelUpScreen.SetActive(false);

    }

    public void GameOver()
    {
        ChangeState(GameState.GameOver);
    }

    void DisplayResults()
    {
        resultScreen.SetActive(true);
        inGameUI.SetActive(false);
    }

    public void LevelUp()
    {
        ChangeState(GameState.LevelUp);

        //playerObj.SendMessage("RemoveAndApplyUpgrades"); 
    }


    public void LevelUpDone()
    {
        isChoosingUpgrade = false;
        Time.timeScale = 1f;

        levelUpScreen.SetActive(false);
        ChangeState(GameState.Gameplay);
    }
}

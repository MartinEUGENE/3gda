using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //un des différents états du jeu créés avec un enum
    public enum GameState
    {
        Gameplay,
        Pause,
        GameOver,
        LevelUp
    }

    [Header("Pause Screen")]
    public GameObject pauseScreen;

    /*[Header("LevelUp Screen")]
    
    */
    //État du jeu à un moment x
    public GameState currentState;
    //État du jeu avant l'état actuel
    public GameState previousState;

    [Header("Damage Text Settings")]
    public Canvas damageTextCanvas;
    public float textFontSize = 20;
    public TMP_FontAsset textFont;
    public Camera referenceCamera;

    private void Awake()
    {
        DisableScreens();

        instance = this;
    }

    void Update()
    {
        //on compare chacune des valeurs 
        switch (currentState)
        {
            case GameState.Gameplay:
                //Code à mettre pour la case de l'état de jeu ici.
                CheckPauseResume();
                break;

            case GameState.Pause:
                //Code à mettre pour la case de l'état de jeu ici. 
                CheckPauseResume();
                break;

            case GameState.GameOver:
                //Code à mettre pour la case de l'état de jeu ici. 
                break;

            case GameState.LevelUp:
                //Code à mettre pour la case de l'état de jeu ici. 
                break;

            //Ligne pour gérer dans un cas où on se retrouve sur le mauvais gamestate.
            default:
                Debug.LogWarning("This GameState does not exist, why are you here ?");
                break;
        }

    }

    IEnumerator GenerateFloatingTextCoroutine(string text, Transform target, float duration = 1.5f, float speed = 10f)
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

            //tmPro.color = new Color(tmPro.color.r, tmPro.color.g, 1 - t / duration);

            //Debug.Log("re");
            if (t>0.5)
            { 
                yOffset += speed * Time.deltaTime;
                //rect.position = referenceCamera.WorldToScreenPoint(target.position + new Vector3(0, yOffset));
                rect.position = rect.position + new Vector3(0, yOffset);
                //Debug.Log("done");
                alpha.alpha -= Time.deltaTime;
                tmPro.fontSize = tmPro.fontSize -10f *Time.deltaTime;
            }
           
        }
    }
    public static void GenerateFloatingText(string text, Transform target, float duration = .75f, float speed = 1.25f)
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

        instance.StartCoroutine(instance.GenerateFloatingTextCoroutine(text, target, duration, speed)); 
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
    }

}

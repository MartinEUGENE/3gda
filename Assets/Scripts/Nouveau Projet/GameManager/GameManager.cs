using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    //État du jeu à un moment x
    public GameState currentState;
    //État du jeu avant l'état actuel
    public GameState previousState;

    private void Awake()
    {
        DisableScreens();
    }

    void Update()
    {
        //on compare chacune des valeurs 
        switch(currentState)
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
    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    public void PauseGame()
    {
        if(currentState != GameState.Pause)
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState == GameState.Pause)
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

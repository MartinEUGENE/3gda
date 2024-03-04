using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    //�tat du jeu � un moment x
    public GameState currentState;
    //�tat du jeu avant l'�tat actuel
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
                //Code � mettre pour la case de l'�tat de jeu ici.
                CheckPauseResume();
                break;

            case GameState.Pause:
                //Code � mettre pour la case de l'�tat de jeu ici. 
                CheckPauseResume();
                break;

            case GameState.GameOver:
                //Code � mettre pour la case de l'�tat de jeu ici. 
                break;

            case GameState.LevelUp:
                //Code � mettre pour la case de l'�tat de jeu ici. 
                break;

            //Ligne pour g�rer dans un cas o� on se retrouve sur le mauvais gamestate.
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

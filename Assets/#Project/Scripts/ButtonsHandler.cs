using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsHandler : MonoBehaviour
{
    public GameManager gameManager;

    public void changeStateViaButton()
    {
        switch (gameManager.currentState)
        {
            case GameState.Start:
                gameManager.SetGameState(GameState.Intro);
                Debug.Log($"Current GameState : {gameManager.currentState}");
                break;
            case GameState.Intro:
                gameManager.SetGameState(GameState.Lvl1);
                Debug.Log($"Current GameState : {gameManager.currentState}");
                break;
            case GameState.TransitionLvl2:
                gameManager.SetGameState(GameState.Lvl2);
                Debug.Log($"Current GameState : {gameManager.currentState}");
                break;
            case GameState.TransitionLvl3:
                gameManager.SetGameState(GameState.Lvl3);
                Debug.Log($"Current GameState : {gameManager.currentState}");
                break;
            default:
                break; 
        }
    }
}
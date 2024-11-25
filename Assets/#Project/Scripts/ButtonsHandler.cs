using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ButtonsHandler : MonoBehaviour
{
    private GameManager gameManager; 

    void Awake() 
    {
        gameManager = GameManager.Instance; 
    }

    public void ChangeStateViaButton()
    {
        if (gameManager == null)
        {
            Debug.LogError("GameManager instance not found!");
            return;
        }

        switch (gameManager.currentState)
        {
            case GameState.Start:
                ChangeState(GameState.Intro);
                break;
            case GameState.Intro:
                ChangeState(GameState.Lvl1);
                break;
            case GameState.TransitionLvl2:
                ChangeState(GameState.Lvl2);
                break;
            case GameState.TransitionLvl3:
                ChangeState(GameState.Lvl3);
                break;
            default:
                Debug.LogWarning("No valid state to change.");
                break;
        }
    }

    private void ChangeState(GameState newState)
    {
        GameManager.Instance.SetGameState(newState);
        Debug.Log($"Current GameState : {newState}");
    }

    public void BackToGlobalView()
    {
        GameCamManager gameCamManager = FindObjectOfType<GameCamManager>();
        if (gameCamManager == null)
        {
            Debug.LogError("GameCamManager instance not found!");
            return;
        }
        gameCamManager.SetCameraActive(gameCamManager.globalViewCamera);
    }
}

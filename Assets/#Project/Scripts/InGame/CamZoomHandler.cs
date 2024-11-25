using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoomHandler : MonoBehaviour
{

// Tenté avec l'héritage ; il sortait les serialize pour les cams, pas pratique.
// Pour avoir une seule ref à mes cams, je fais comme ça. 
    GameCamManager gameCamManager;
    public UIHandler uiHandler;
    void Start()
    {
        gameCamManager = FindObjectOfType<GameCamManager>();
    }
    void OnMouseDown()
    {
        Debug.Log($"clicked on {gameObject.tag}");
        switch (gameObject.tag) 
        {
            case "Attick":
                gameCamManager.SetCameraActive(gameCamManager.attickCamera);
                uiHandler.UpdateUIVisibility();
                break;
            case "Dormitory":
                gameCamManager.SetCameraActive(gameCamManager.dormitoryCamera);
                uiHandler.UpdateUIVisibility();
                break;
            case "Kitchen":
                gameCamManager.SetCameraActive(gameCamManager.kitchenCamera);
                uiHandler.UpdateUIVisibility();
                break;
            case "Theater":
                gameCamManager.SetCameraActive(gameCamManager.theaterCamera);
                uiHandler.UpdateUIVisibility();
                break;
            case "Lobby":
                gameCamManager.SetCameraActive(gameCamManager.lobbyCamera);
                uiHandler.UpdateUIVisibility();
                break;
            case "Board":
                gameCamManager.SetCameraActive(gameCamManager.boardCamera);
                uiHandler.UpdateUIVisibility();
                break;
            case "Projo":
                gameCamManager.SetCameraActive(gameCamManager.projoCamera);
                uiHandler.UpdateUIVisibility();
                break;
            default:
                Debug.LogWarning("No camera associated with tag: " + gameObject.tag);
                break;
        }
    }
}
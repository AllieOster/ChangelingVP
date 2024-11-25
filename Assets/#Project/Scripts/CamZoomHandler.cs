using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoomHandler : MonoBehaviour
{

// Tenté avec l'héritage ; il sortait les serialize pour les cams, pas pratique.
// Pour avoir une seule ref à mes cams, je fais comme ça. 
    GameCamManager gameCamManager;
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
                break;
            case "Dormitory":
                gameCamManager.SetCameraActive(gameCamManager.dormitoryCamera);
                break;
            case "Kitchen":
                gameCamManager.SetCameraActive(gameCamManager.kitchenCamera);
                break;
            case "Theater":
                gameCamManager.SetCameraActive(gameCamManager.theaterCamera);
                break;
            case "Lobby":
                gameCamManager.SetCameraActive(gameCamManager.lobbyCamera);
                break;
            case "Board":
                gameCamManager.SetCameraActive(gameCamManager.boardCamera);
                break;
            case "Projo":
                gameCamManager.SetCameraActive(gameCamManager.projoCamera);
                break;
            default:
                Debug.LogWarning("No camera associated with tag: " + gameObject.tag);
                break;
        }
    }
}
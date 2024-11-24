using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameSceneCameraManager : CameraManager
{
    private CameraManager cameraManager;

    void Start()
    {
        cameraManager = FindObjectOfType<CameraManager>(); 
        if (cameraManager == null)
        {
            Debug.LogError("CameraManager not found! Please ensure it is present in the scene.");
        }
    }

    void OnMouseDown()
    {
        if (cameraManager != null) 
        {
            // Vérifier la tag de l'objet sur lequel on a cliqué
            switch (gameObject.tag) 
            {
                case "Attick":
                    cameraManager.SetCameraActive(cameraManager.attickCamera);
                    break;
                case "Dormitory":
                    cameraManager.SetCameraActive(cameraManager.dormitoryCamera);
                    break;
                case "Kitchen":
                    cameraManager.SetCameraActive(cameraManager.kitchenCamera);
                    break;
                case "Theater":
                    cameraManager.SetCameraActive(cameraManager.theaterCamera);
                    break;
                case "Lobby":
                    cameraManager.SetCameraActive(cameraManager.lobbyCamera);
                    break;
                case "Board":
                    cameraManager.SetCameraActive(cameraManager.boardCamera);
                    break;
                default:
                    Debug.LogWarning("No camera associated with tag: " + gameObject.tag);
                    break;
            }
        }
    }
}
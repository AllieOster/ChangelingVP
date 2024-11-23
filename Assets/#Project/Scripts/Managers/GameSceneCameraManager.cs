using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameSceneCameraManager : CameraManager
{
    CameraManager cameraManager;
    [SerializeField] CinemachineVirtualCamera attickCamera;
    [SerializeField] CinemachineVirtualCamera dormitoryCamera;
    [SerializeField] CinemachineVirtualCamera kitchenCamera;
    [SerializeField] CinemachineVirtualCamera theaterCamera;
    [SerializeField] CinemachineVirtualCamera lobbyCamera;

    [SerializeField] GameObject roomColliders;

    void Start ()
    {
        roomColliders.SetActive(true);
    }
    // [SerializeField] CinemachineVirtualCamera boardCamera;
    void OnMouseDown()
    {
        Debug.Log("Clicked on something");
            switch (gameObject.tag) 
            {
                case "Attick":
                    cameraManager.SetCameraActive(attickCamera);
                    break;
                case "Dormitory":
                    cameraManager.SetCameraActive(dormitoryCamera);
                    break;
                case "Kitchen":
                    cameraManager.SetCameraActive(kitchenCamera);
                    break;
                case "Theater":
                    cameraManager.SetCameraActive(theaterCamera);
                    break;
                case "Lobby":
                    cameraManager.SetCameraActive(lobbyCamera);
                    break;
                // case "Board":
                //     cameraManager.SetCameraActive(boardCamera);
                //     break;
                default:
                    break;
            }
        }
    }
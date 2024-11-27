using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameCamManager : CameraManager
{

    public enum GameCamera {
        Attic,
        Dormitory,
        Kitchen,
        Theater,
        Lobby,
        Board,
        Projo,
        GlobalView,
    }

    public CinemachineVirtualCamera atticCamera;
    public CinemachineVirtualCamera dormitoryCamera;
    public CinemachineVirtualCamera kitchenCamera;
    public CinemachineVirtualCamera theaterCamera;
    public CinemachineVirtualCamera lobbyCamera;
    public CinemachineVirtualCamera boardCamera;
    public CinemachineVirtualCamera projoCamera;
    public CinemachineVirtualCamera globalViewCamera;
    void Awake()
    {
        InitializeCamera();
    }
    void InitializeCamera()
    {
        SetCameraActive(globalViewCamera);
    }

    public void SetCameraActive(GameCamera cam) {
        switch (cam)
        {
            case GameCamera.Attic:
                SetCameraActive(atticCamera);
                break;
            case GameCamera.Dormitory:
                SetCameraActive(dormitoryCamera);
                break;
            case GameCamera.Board:
                SetCameraActive(boardCamera);
                break;
              case GameCamera.Kitchen:
                SetCameraActive(kitchenCamera);
                break;
            case GameCamera.Theater:
                SetCameraActive(theaterCamera);
                break;
            case GameCamera.Lobby:
                SetCameraActive(lobbyCamera);
                break;
              case GameCamera.Projo:
                SetCameraActive(projoCamera);
                break;
            case GameCamera.GlobalView:
                SetCameraActive(globalViewCamera);
                break;
        }
    }

}
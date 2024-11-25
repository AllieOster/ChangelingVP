using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameCamManager : CameraManager
{
    public CinemachineVirtualCamera attickCamera;
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
}
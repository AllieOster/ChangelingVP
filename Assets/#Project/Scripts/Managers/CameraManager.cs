using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera attickCamera;
    public CinemachineVirtualCamera dormitoryCamera;
    public CinemachineVirtualCamera kitchenCamera;
    public CinemachineVirtualCamera theaterCamera;
    public CinemachineVirtualCamera lobbyCamera;
    public CinemachineVirtualCamera boardCamera;
    public CinemachineVirtualCamera globalViewCamera;
    public CinemachineVirtualCamera projoCamera;
    private CinemachineVirtualCamera activeCamera;
    public void SetCameraActive(CinemachineVirtualCamera cameraToActivate)
    {
        if (cameraToActivate == null)
        {
            Debug.LogWarning("Pas de camera à activer !");
            return;
        }

        ResetPreviousCamera();

        activeCamera = cameraToActivate;
        activeCamera.Priority = 20;
        GameManager.Instance.SetActiveCamera(activeCamera);
    }

    private void ResetPreviousCamera()
    {
        if (activeCamera != null)
        {
            activeCamera.Priority = 10; 
        }
        else
        {
            Debug.Log("La camera est égale à nulle au moment du reset");
        }
    }
}
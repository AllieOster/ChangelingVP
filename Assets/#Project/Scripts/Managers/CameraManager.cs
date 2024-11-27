using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private CinemachineVirtualCamera activeCamera;

    public void SetCameraActive(CinemachineVirtualCamera cameraToActivate)
    {
        if (GameManager.Instance.activeCamera != null) 
        {
        ResetPreviousCamera();
        }

        activeCamera = cameraToActivate;
        activeCamera.Priority = 20;

        if (activeCamera != null)
        {
        GameManager.Instance.SetActiveCamera(activeCamera);
        }
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
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private CinemachineVirtualCamera activeCamera;
    public void SetCameraActive(CinemachineVirtualCamera cameraToActivate)
        {
            ResetPreviousCamera();

            activeCamera = cameraToActivate;
            activeCamera.Priority = 20;
        }

        private void ResetPreviousCamera()
        {
            if (activeCamera != null)
            {
                activeCamera.Priority = 10;
            }
        }
}
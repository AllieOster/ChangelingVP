using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoomHandler : MonoBehaviour
{
    GameCamManager gameCamManager;
    public UIAndCollidersHandler uiandCollidersHandler;

    public GameCamManager.GameCamera cameraToActivate; //variable référence enum

    void Awake()
    {
        gameCamManager = FindObjectOfType<GameCamManager>();
    }
    public void ZoomToCamera()
    {
        gameCamManager.SetCameraActive(cameraToActivate);
        if (cameraToActivate == GameCamManager.GameCamera.GlobalView)
        {
            uiandCollidersHandler.setUIorColliderActive(true, false);
        }
        else
        {
            uiandCollidersHandler.setUIorColliderActive(false, true);
        }
        Debug.Log($"clicked on {gameObject.tag}");
    }
}
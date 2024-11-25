using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CollidersHandler : MonoBehaviour
{
    [SerializeField] GameObject colliders; 
    void Awake()
    {
      colliders.SetActive(true);
      Debug.Log($" Colliders actifs = {IsCollidersActive()}");
    }
    public bool IsCollidersActive()
    {
        CinemachineVirtualCamera activeCamera = GameManager.Instance.GetActiveCamera();
        if (activeCamera == null)
        {
            return false;
        }

        if (activeCamera.gameObject.name == "GlobalViewCamera")
        {
            return true; 
        }
        else
        {
            return false;
        }
    }
    public void UpdateCollidersActivity()
    {
        colliders.SetActive(IsCollidersActive());
    }
}
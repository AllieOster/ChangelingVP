using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject uIElements; 
    void Awake()
    {
      //uIElements.SetActive(false);
      Debug.Log($" Ui actif = {IsUIActive()}");
    }
    public bool IsUIActive()
    {
        CinemachineVirtualCamera activeCamera = GameManager.Instance.GetActiveCamera();
        if (activeCamera == null)
        {
            Debug.Log($"sam: [UIHandler] active camera null");
            return false;
        }

        if (activeCamera.gameObject.name == "GlobalViewCamera")
        {
            Debug.Log($"sam: [UIHandler] active camera global");
            return false; 
        }
        else
        {
            Debug.Log($"sam: [UIHandler] active camera UI");
            return true;
        }
    }
    public void UpdateUIVisibility()
    {
        Debug.Log($"sam: {IsUIActive()}");
        uIElements.SetActive(IsUIActive());
    }
}
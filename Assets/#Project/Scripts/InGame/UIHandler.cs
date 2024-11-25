using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject uIElements; 
    void Start()
    {
      uIElements.SetActive(false);
      Debug.Log($" Ui actif = {IsUIActive()}");
    }
    public bool IsUIActive()
    {
        CinemachineVirtualCamera activeCamera = GameManager.Instance.GetActiveCamera();
        if (activeCamera == null)
        {
            return false;
        }

        if (activeCamera.gameObject.name == "GlobalViewCamera")
        {
            return false; 
        }
        else
        {
            return true;
        }
    }
    public void UpdateUIVisibility()
    {
        uIElements.SetActive(IsUIActive());
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UIAndCollidersHandler : MonoBehaviour
{
    [SerializeField] private GameObject uiElements;
    [SerializeField] private GameObject RoomColliders; 
    private void Awake()
    {
        InitializeUIColliders();
    }

    public void InitializeUIColliders()
    {
        setUIorColliderActive(true, false);
    }

    public void setUIorColliderActive(bool collidersActivation, bool uiActivation) 
    {
        RoomColliders.SetActive(collidersActivation);
        uiElements.SetActive(uiActivation);
    }
}

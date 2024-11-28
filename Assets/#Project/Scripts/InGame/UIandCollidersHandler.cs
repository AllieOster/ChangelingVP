using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UIAndCollidersHandler : MonoBehaviour
{
    [SerializeField] private GameObject uiElements;
    [SerializeField] private GameObject roomColliders; 

    protected void Awake()
    {
        InitializeUIColliders();
    }
    public void InitializeUIColliders()
    {
        setUIorColliderActive(true, false);
    }
    public void setUIorColliderActive(bool collidersActivation, bool uiActivation) 
    {
        roomColliders.SetActive(collidersActivation);
        uiElements.SetActive(uiActivation);
    }
}
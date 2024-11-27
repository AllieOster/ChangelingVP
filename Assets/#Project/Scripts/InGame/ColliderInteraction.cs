using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderInteraction : MonoBehaviour
{  
    public bool interactable = true;
    public UnityEvent onClick;
    
    void OnMouseDown() {
        if (interactable) {
            onClick?.Invoke();
        }
    }
}
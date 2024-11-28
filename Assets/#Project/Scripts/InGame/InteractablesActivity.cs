using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractablesActivity : MonoBehaviour
{  
    public bool interactable = true;
    public UnityEvent onClick;
    
    void OnMouseDown() {
        if (interactable) {
            onClick?.Invoke();
        }
    }
}
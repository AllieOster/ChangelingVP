using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 initialPosition; 
    static bool canIDrag; 

    void Start()
    {
        canIDrag = false;
    }

    public void SetDragPermission(bool permission)
    {
        canIDrag = permission; 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!canIDrag)
        {
            Debug.Log("canDrag est à false");
            return; 
        }
            
        RectTransform rt = GetComponent<RectTransform>();
        initialPosition = rt.position; 
        Debug.Log("Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!canIDrag) return; 

        RectTransform rt = GetComponent<RectTransform>();
        Vector3 worldPosition;

        if (RectTransformUtility.ScreenPointToWorldPointInRectangle((RectTransform)transform.parent, eventData.position, eventData.pressEventCamera, out worldPosition))
        {
            rt.position = worldPosition; 
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!canIDrag) return; 

        RectTransform rt = GetComponent<RectTransform>();

        // Retourne à la position initiale si l'objet n'est pas déposé
        rt.position = initialPosition; 
        Debug.Log("Objet retour à la position initiale.");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit");
    }
}
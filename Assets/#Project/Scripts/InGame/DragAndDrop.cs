using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 initialPosition; 
    public bool canIDrag; 

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
        Debug.Log( "canDrag est à false");
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

        Debug.Log("End Drag");
        RectTransform rt = GetComponent<RectTransform>();
        rt.position = initialPosition; 
        Debug.Log("Returned to initial position");
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
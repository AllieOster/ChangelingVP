using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlots : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 initialPosition; 
    public void OnBeginDrag(PointerEventData eventData)
    {
        RectTransform rt = GetComponent<RectTransform>();
        initialPosition = rt.position; 
        Debug.Log("Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    { 
        RectTransform rt = GetComponent<RectTransform>();

        Vector3 worldPosition;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle((RectTransform)transform.parent, eventData.position, eventData.pressEventCamera, out worldPosition))
        {
            rt.position = worldPosition; 
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
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

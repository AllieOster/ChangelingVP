using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 initialPosition; 
    static bool canIDrag; 
    public DropZonePapers dropZone;
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

        RectTransform rt = GetComponent<RectTransform>();

        // Déterminez si l'objet a été déposé dans la drop zone
        if (dropZone != null && RectTransformUtility.RectangleContainsScreenPoint(dropZone.GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera))
        {
            Debug.Log("Objet déposé sur la Drop Zone !");
            dropZone.AddToGivenList(this.GetComponent<Item>());
        }
        else
        {
            Debug.Log("Objet déposé en dehors de la Drop Zone.");
            rt.position = initialPosition; // Retourne à la position initiale si l'endroit est incorrect
        }
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
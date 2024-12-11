using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 initialPosition; 
    static bool canIDrag; 
    private InventoryManager inventoryManager;
    private int currentSlotIndex = -1; 

    void Start()
    {
        canIDrag = false;
        inventoryManager = FindObjectOfType<InventoryManager>(); 
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
        for (int i = 0; i < inventoryManager.slots.Length; i++)
        {
            if (inventoryManager.slots[i].rectTransform == rt)
            {
                currentSlotIndex = i;
                Debug.Log($"Begin Drag from slot index: {currentSlotIndex}");
                break;
            }
        }

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
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(eventData.position), Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("DirDropZone"))
        {
            Debug.Log("Objet déposé dans la DropZone");
            DropZonePapers dropZone = hit.collider.GetComponent<DropZonePapers>();
            if (dropZone != null && currentSlotIndex >= 0)
            {
                Item currentItem = inventoryManager.inventoryItems[currentSlotIndex];
                dropZone.AddToGivenList(currentItem); 
                gameObject.SetActive(false); 
            }
        }
        else
        {
            rt.position = initialPosition; 
            Debug.Log("Objet retour à la position initiale.");
        }
        currentSlotIndex = -1;
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

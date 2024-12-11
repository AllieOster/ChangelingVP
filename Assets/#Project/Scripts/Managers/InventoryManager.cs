using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Item> inventoryItems = new List<Item>();
    public Image[] slots;
    public bool isInventoryFull = false;
    private InventoryState currentState;
    public DragAndDrop dragAndDrop;

    private void Start()
    {
        SetInventoryState(GameManager.Instance.GetGameState());
    }
    public void SetInventoryState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Lvl1:
                currentState = new Lvl1InventoryState(this);
                break;
            case GameState.Lvl2:
                currentState = new Lvl2InventoryState(this);
                break;
            case GameState.Lvl3:
                currentState = new Lvl3InventoryState(this);
                break;
            default:
                throw new ArgumentException("GameState non pris en charge.");
        }
    }

    public void AddItem(Item newItem)
    {
        GameState currentGameState = GameManager.Instance.GetGameState();

        if (newItem.associatedGameState == currentGameState) {
            if (inventoryItems.Count < slots.Length)
            {
                inventoryItems.Add(newItem);
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i].sprite == null)
                    {
                        // if (slots[i] == newItem.icon){} // CHECK PAR ICI !!!! 
                        slots[i].sprite = newItem.icon;
                        newItem.gameObject.SetActive(false);
                        Image imageComponent = slots[i].GetComponent<Image>();
                        if (imageComponent != null)
                        {
                            Color color = imageComponent.color;
                            color.a = 1f; 
                            imageComponent.color = color;
                        }

                        Debug.Log($"Ajout de '{newItem.itemName}' dans le slot {i}.");
                        break;
                    }
                }

                if (inventoryItems.Count == slots.Length)
                {
                    Debug.Log("L'inventaire est maintenant plein !");
                    isInventoryFull = true;
                    currentState.HandleInventoryFull(); 
                }
            }
            else
            {
                Debug.Log("Impossible d'ajouter l'élément, l'inventaire est déjà plein.");
            }
        }
        else {
            Debug.Log("Not the right lvl to try and add this one");
        }
    }


#region Coroutines Clear + ChangeScene Lvl 1
    public IEnumerator ClearInventoryCoroutine(float delay)
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < slots.Length; i++)
        {  
            Image imageComponent = slots[i].GetComponent<Image>();
            Color color = imageComponent.color;
                            color.a = 0f; 
                            imageComponent.color = color;

            slots[i].sprite = null; 
            
            yield return new WaitForSeconds(delay); 
        }
        inventoryItems.Clear(); 
    }
    public void ClearInventory(float delay)
    {
        StartCoroutine(ClearInventoryCoroutine(delay));
    }

    public IEnumerator ChangeSceneLvl1Coroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameState currentGameState = GameManager.Instance.GetGameState();
        Debug.Log($"State avant changement : {currentGameState}");
        ChangeState(GameState.TransitionLvl2);
        LoadSceneManager.ChangeScene("TransitionOneScene");
    }
    public void ChangeSceneLvl1(float delay)
    {
        StartCoroutine(ChangeSceneLvl1Coroutine(delay));
    }
            private void ChangeState(GameState newState)
    {
        GameManager.Instance.SetGameState(newState);
        Debug.Log($"Current GameState : {newState}");
    }
#endregion

    public void SetCanIDrag(bool dragPermission)
    {
        dragAndDrop.SetDragPermission(dragPermission);
    }
    
    public void RemoveItem(Item itemToRemove)
{
    if (inventoryItems.Contains(itemToRemove))
    {
        inventoryItems.Remove(itemToRemove);
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].sprite == itemToRemove.icon) // POURQUOIIII ???
            {
                slots[i].sprite = null; // Enlève uniquement l'icône de l'inventaire
                break; 
            }
        }
    }
}

}
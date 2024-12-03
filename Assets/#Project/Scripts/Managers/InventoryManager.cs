using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Item> inventoryItems = new List<Item>(); 
    public Image[] slots; 
    GameState gameState = GameManager.Instance.GetGameState();
    public void AddItem(Item newItem)
    {
        if (inventoryItems.Count < slots.Length)
        {
            inventoryItems.Add(newItem);

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].sprite == null)
                {
                    slots[i].sprite = newItem.icon;
                    break;
                }
            }

            if (inventoryItems.Count == slots.Length)
            {
                Debug.Log("Inventory is now full!");
                if (gameState == GameState.Lvl1)
                {
                ClearInventory(0.5f);
                ChangeSceneLvl1(3.5f);
                }
            }
        }
        else
        {
            Debug.Log("Cannot add item, inventory is already full.");
        }
    }

#region Coroutines Clear + ChangeScene Lvl 1
    public IEnumerator ClearInventoryCoroutine(float delay)
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].sprite = null; 
            yield return new WaitForSeconds(delay); 
        }
        inventoryItems.Clear(); 
    }
    public IEnumerator ChangeSceneLvl1Coroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameManager.Instance.SetGameState(GameState.TransitionLvl2);
        LoadSceneManager.ChangeScene("TransitionOneScene");
    }
    public void ChangeSceneLvl1(float delay)
    {
        StartCoroutine(ChangeSceneLvl1Coroutine(delay));
    }
    public void ClearInventory(float delay)
    {
        StartCoroutine(ClearInventoryCoroutine(delay));
    }
#endregion
}
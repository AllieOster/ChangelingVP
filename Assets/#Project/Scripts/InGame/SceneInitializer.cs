using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public GameObject itemsLvl1;
    public GameObject itemsLvl2;
    public GameObject itemsLvl3;

    void Awake()
    {
        InitializeScene();
    }

    public void InitializeScene()
    {
        GameState currentGameState = GameManager.Instance.GetGameState();
        if (currentGameState == GameState.Lvl1)
        {
            ActivateItems(true, true, true);
        }
        else if (currentGameState == GameState.Lvl2)
        {
            ActivateItems(false, true, true);
        }
        else if (currentGameState == GameState.Lvl3)
        {
            ActivateItems(false, false, true);
        }
    }
    public void ActivateItems(bool items1, bool items2, bool items3)
    {
        itemsLvl1.SetActive(items1);
        itemsLvl2.SetActive(items2);
        itemsLvl3.SetActive(items3);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl1InventoryState : InventoryState
{
    public Lvl1InventoryState(InventoryManager manager) : base(manager) { }

    public override void HandleInventoryFull()
    {
        inventoryManager.ClearInventory(0.5f);
        inventoryManager.ChangeSceneLvl1(3.5f);
    }


}
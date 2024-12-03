using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryState
{
    protected InventoryManager inventoryManager;
    protected MonoBehaviour coroutineOwner;

    public InventoryState(InventoryManager manager)
    {
        inventoryManager = manager;
    }

    public abstract void HandleInventoryFull();
}

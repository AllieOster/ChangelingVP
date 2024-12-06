using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3InventoryState : InventoryState
{
    public Lvl3InventoryState(InventoryManager manager) : base(manager) { }

    public override void HandleInventoryFull()
    {
        // Comportement pour Lvl3 à implémenter (presque même que le deux)
        Debug.Log("Inventaire plein au niveau 3");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3InventoryState : InventoryState
{
    public Lvl3InventoryState(InventoryManager manager) : base(manager) { }

    public override void HandleInventoryFull()
    {
        // Comportement pour Lvl3 à implémenter
        Debug.Log("Inventaire plein au niveau 3. Comportement spécifique ici.");
    }
}

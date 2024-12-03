using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2InventoryState : InventoryState
{
    public Lvl2InventoryState(InventoryManager manager) : base(manager) { }

    public override void HandleInventoryFull()
    {
        // Comportement pour Lvl2 à implémenter (drag & drop ???)
        Debug.Log("Inventaire plein au niveau 2. Comportement spécifique ici.");
    }
}

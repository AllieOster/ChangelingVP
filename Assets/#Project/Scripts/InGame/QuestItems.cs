using UnityEngine;
public class Item : MonoBehaviour
{
    public string itemName; 
    public GameState associatedGameState;
    public Sprite icon; 
    private InventoryManager inventory; 
    public int dedicatedSlot;

    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
    }
    void OnMouseDown() 
    {
        Item item = GetComponent<Item>();
        if (item != null && inventory != null)
        {
            inventory.AddItem(item);
        }
    }
}
using UnityEngine;
public class Item : MonoBehaviour
{
    public string itemName; 
    public Sprite icon; 
    private InventoryManager inventory; 

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
            gameObject.SetActive(false);
        }
    }
}
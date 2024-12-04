using UnityEngine;
public class Item : MonoBehaviour
{
    public string itemName; 
    public GameState associatedGameState;
    public Sprite icon; 
    private InventoryManager inventory; 

    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
        // ActivateItemsBasedOnState();
    }
    void OnMouseDown() 
    {
        Item item = GetComponent<Item>();
        if (item != null && inventory != null)
        {
            inventory.AddItem(item);
        }
    }

    // void ActivateItemsBasedOnState()👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿
    // {
    //     GameState currentGameState = GameManager.Instance.GetGameState();
    //     if (currentGameState == associatedGameState)
    //     {
    //         gameObject.SetActive(true);
    //     }
    // } 👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿👿
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZonePapers : MonoBehaviour
{
    public List<Item> papersInOrder = new List<Item>();
    public List<Item> givenPapers = new List<Item>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            Debug.Log("Un objet est entré dans la zone : " + item.itemName);
            AddToGivenList(item);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            Debug.Log("Un objet est sorti de la zone : " + item.itemName);

        }
    }

    public void OnMouseDown()
    {
        Debug.Log("cliqué sur directeur");
    }

    public void AddToGivenList(Item paper)
    {
        givenPapers.Add(paper);
        CheckOrder();
    }

    private void CheckOrder()
    {
        if (givenPapers.Count > papersInOrder.Count || 
            givenPapers[givenPapers.Count - 1] != papersInOrder[givenPapers.Count - 1])
        {
            Debug.Log("Erreur lors du dépôt des papiers. Réinitialisation...");
            ResetGivenPapers();
        }
        else if (givenPapers.Count == papersInOrder.Count)
        {
            Debug.Log("Niveau validé !");
            ResetGivenPapers();
            // méthode de validation à mettre ici !!!??? Event quoi ? 
        }
    }

    private void ResetGivenPapers()
    {
        foreach (var paper in givenPapers)
        {
            if (paper != null)
            {
                paper.gameObject.SetActive(true); 
                InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
                inventoryManager.RemoveItem(paper); 
            }
        }
        givenPapers.Clear();
    }
}

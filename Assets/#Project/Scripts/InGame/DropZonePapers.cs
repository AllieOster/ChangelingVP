using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZonePapers : MonoBehaviour
{
    public List<Item> papersInOrder = new List<Item>();
    public List<Item> givenPapers = new List<Item>();

    public void OnMouseDown()
    {
        Debug.Log("cliqué sur directeur");
    }
    public void AddToGivenList(Item paper)
    {
        if (paper == null)
        {
            Debug.LogError("Tentative d'ajouter un objet null à givenPapers !");
            return;
        }

        givenPapers.Add(paper);
        CheckOrder();
    }

    private void CheckOrder()
    {
        Debug.Log("Nombre de papiers donnés : " + givenPapers.Count);
        Debug.Log("Nombre de papiers en ordre : " + papersInOrder.Count);

        if (givenPapers.Count > papersInOrder.Count)
        {
            Debug.Log("Erreur lors du dépôt des papiers. Réinitialisation...");
            ResetGivenPapers();
            return;
        }
        
        for (int i = 0; i < givenPapers.Count; i++)
        {
            if (givenPapers[i] == null || papersInOrder[i] == null)
            {
                Debug.LogError("Un des objets Item est nul à l'index " + i);
                ResetGivenPapers();
                return;
            }

            if (givenPapers[i].icon != papersInOrder[i].icon)
            {
                Debug.Log("Erreur lors du dépôt des papiers. Réinitialisation...");
                ResetGivenPapers();
                return;
            }
        }

        if (givenPapers.Count == papersInOrder.Count)
        {
            Debug.Log("Niveau validé !");
            ResetGivenPapers();
            // Appeler méthode de validation ici ! =) 
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

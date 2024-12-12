using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class DropZonePapers : MonoBehaviour
{
    public List<Item> papersInOrder = new List<Item>();
    public List<Item> givenPapers = new List<Item>();
    public void AddToGivenList(Item item)
    {
        if (item != null)
        {
            givenPapers.Add(item);
            Debug.Log($"Item '{item.itemName}' added to drop zone.");
            foreach (var thing in givenPapers) 
            {
                Debug.Log($"List updated, list : {thing}");
            }
            CheckOrder();
        }
        else
        {
            Debug.LogWarning("Error: Attempted to add a null item to the drop zone.");
        }
    }


    private void CheckOrder()
    {
        Debug.Log("Nombre de papiers donnés : " + givenPapers.Count);

        if (givenPapers.Count > papersInOrder.Count)
        {
            Debug.Log("Erreur lors du dépôt des papiers. Réinitialisation... Trop de papiers");
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

            if (givenPapers[i] != papersInOrder[i])
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
        givenPapers.Clear();
        foreach (var papers in givenPapers){
        papers.gameObject.SetActive(true);
        }
    }
}

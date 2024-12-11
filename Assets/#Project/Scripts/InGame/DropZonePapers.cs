using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class DropZonePapers : MonoBehaviour
{
    public List<Image> papersInOrder = new List<Image>();
    public List<Image> givenPapers = new List<Image>();

    public void OnMouseDown()
    {
        Debug.Log("cliqué sur directeur");
    }
    public void AddToGivenList(Image paper)
    {
        if (paper == null)
        {
            Debug.LogError("Tentative d'ajouter un objet null à givenPapers !");
            return;
        }

        givenPapers.Add(paper); // changé pour Image
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
    }
}

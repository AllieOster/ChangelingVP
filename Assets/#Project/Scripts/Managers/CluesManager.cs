using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CluesManager : MonoBehaviour
{
    public Clues clueToDeactivate;
    public enum Clues 
    {
        Board,
        Proj,
        Director, 
    }


    public void DeactivateClue (Clues clue)
    {
        switch (clue)
        {
            case Clues.Board:
                break;
            case Clues.Proj:
                break;
            case Clues.Director:
                break;
        }
    }

}
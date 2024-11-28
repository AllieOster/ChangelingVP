using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CluesHandler : MonoBehaviour
{
    public void DeactivateClue()
    {
        Debug.Log($"{name}");
        gameObject.SetActive(false);
    }
}

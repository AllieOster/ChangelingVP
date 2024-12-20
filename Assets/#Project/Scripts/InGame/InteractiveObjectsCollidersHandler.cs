using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectsCollidersHandler : MonoBehaviour
{
    [SerializeField] private GameObject boardCollider;
    [SerializeField] private GameObject projCollider;

    void Awake()
    {
        InitializeColliders();
    }
   public void InitializeColliders()
   {
        setUIorColliderActive(true);
   } 

   public void DeActivateCollider(GameObject collider)
   {
        setUIorColliderActive(false);
   } 
   public void ReActivateCollider()
   {
        setUIorColliderActive(true);
   }

   // ☠️☠️☠️☠️☠️ Ces deux là on peut en faire une fonction booléenne ==> check check ☠️☠️☠️☠️☠️

       public void setUIorColliderActive(bool collidersActivation) 
    {
        boardCollider.SetActive(collidersActivation);
    }
}
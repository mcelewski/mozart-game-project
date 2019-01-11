using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySpace : MonoBehaviour 
{
    public List<GameObject> slots = new List<GameObject>();

    public void AddToInventory()
    {
        foreach (var item in slots)
        {
            if (item.transform.childCount > 0)
            {
                Debug.Log("Add object");
                
            }
        }
    }
}


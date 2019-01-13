using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class InventorySpace : MonoBehaviour 
{
    public List<GameObject> slots = new List<GameObject>();

    public void AddToInventory(int itemId)
    {
        StartCoroutine(PushToInventory(SearchFreeSlot(), itemId));
    }

    int SearchFreeSlot()
    {
        int i = 0;

        for (; i < slots.Count; i++)
        {
            if (!slots[i].activeSelf)
            {
                break;
            }
        }
        return i;
    }

    IEnumerator PushToInventory(int index, int itemId)
    {
        yield return new WaitForSeconds(.5f);
        
        Debug.Log("inventory slot, " + index + " item ID: " + itemId);
        slots[index].SetActive(true);
        // change image to image id
    }
}


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
        Debug.Log("slot to add in : " + SearchFreeSlot());
        PushToInventory(SearchFreeSlot(),itemId);
    }

    int SearchFreeSlot()
    {
        int slotnum = 0;
        
        var freeslot = slots.First(x => !x.activeSelf);
        slotnum = freeslot.GetComponent<SlotBehaviour>().GetSlotNumber();

        return slotnum;
    }

    void PushToInventory(int index, int itemId)
    {
        Debug.Log("index, " + index + " item ID: " + itemId);
        slots[index-1].SetActive(true);
        // change image to image id
    }
}


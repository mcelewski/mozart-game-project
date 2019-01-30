using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFuel : MonoBehaviour
{
    public InventorySpace inventory;
    public ItemInfo info;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        inventory.SetIntemToAdd(info.id);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        inventory.SetIntemToAdd(0);
    }
}

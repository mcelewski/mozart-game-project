using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public InventorySpace inventory;
    public ItemInfo info;
    
    public void SetLight()
    {
        var light = gameObject.GetComponent<Light>();

        if (!light.enabled)
        {
            light.enabled = true;
        }
    }
    
    public void DisableLight()
    {
        var light = gameObject.GetComponent<Light>();

        if (light.enabled)
        {
            light.enabled = false;
        }
    }

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

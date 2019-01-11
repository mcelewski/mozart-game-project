using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowToPickUpItem : MonoBehaviour 
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        UserInteractListener.AllowToPickUp(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        UserInteractListener.AllowToPickUp(false);
    }
}

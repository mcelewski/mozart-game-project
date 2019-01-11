using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowToPickUpItem : MonoBehaviour 
{
    
    private static bool pickUp;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        //Debug.Log("Allow to pickup");
        pickUp = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        //Debug.Log("Deny to pick up");
        pickUp = false;
    }
    
    public static bool AllowToPickUp()
    {
        return pickUp;
    }
}

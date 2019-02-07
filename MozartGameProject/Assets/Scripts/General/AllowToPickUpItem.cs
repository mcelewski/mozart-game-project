using UnityEngine;

public class AllowToPickUpItem : MonoBehaviour
{
    static bool pickUp;

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        pickUp = true;
    }

    void OnTriggerExit2D(Collider2D other)
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

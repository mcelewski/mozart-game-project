using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderObj : MonoBehaviour
{
    private static bool allowClimb;

    public static bool AllowUseLadder()
    {
        return allowClimb;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        allowClimb = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
      
        allowClimb = false;
    }
}

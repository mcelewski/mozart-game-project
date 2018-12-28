using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderObj : MonoBehaviour
{
    private static bool allowClimb;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        PlatformBehaviour.SetPlatformTrigger(true);
        allowClimb = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        PlatformBehaviour.SetPlatformTrigger(false);
        allowClimb = false;
    }
    
    public static bool AllowUseLadder()
    {
        return allowClimb;
    }
}

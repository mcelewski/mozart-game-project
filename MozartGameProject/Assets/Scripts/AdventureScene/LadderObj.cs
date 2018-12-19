using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderObj : MonoBehaviour
{
    private static bool allowClimb;

    private void Start()
    {
        // Ladder heigh multiply by 2 beacouse it's calculated from center of an object
        LadderLocalSize = gameObject.transform.localScale.y * 2;
        LadderLocalPosition = gameObject.transform.localPosition.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
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

    public static float LadderLocalSize{ get; private set; }
    public static float LadderLocalPosition{ get; private set; }
}

using UnityEngine;

public class LadderObj : MonoBehaviour
{
    static bool allowClimb;

    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        PlatformBehaviour.SetPlatformTrigger(true);
        allowClimb = true;
    }

    void OnTriggerExit2D(Collider2D other)
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

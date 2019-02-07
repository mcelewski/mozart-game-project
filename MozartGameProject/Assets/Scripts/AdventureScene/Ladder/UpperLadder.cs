using UnityEngine;

public class UpperLadder : MonoBehaviour
{
    static bool activateUpper;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            activateUpper = true;
        LowerLadder.UpdateIfNeed();
        //Debug.Log("Upper active");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            activateUpper = false;
        LowerLadder.UpdateIfNeed();
        //Debug.Log("Upper unactive");
    }

    public static bool GetActivateStatus()
    {
        return activateUpper;
    }
}

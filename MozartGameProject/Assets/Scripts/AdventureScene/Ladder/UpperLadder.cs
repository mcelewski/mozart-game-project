using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperLadder : MonoBehaviour
{
    private static bool activateUpper;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            activateUpper = true;
        LowerLadder.UpdateIfNeed();
        //Debug.Log("Upper active");
    }

    private void OnTriggerExit2D(Collider2D other)
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

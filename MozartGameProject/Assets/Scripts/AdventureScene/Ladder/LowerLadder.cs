using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerLadder : MonoBehaviour
{
    private static bool turnDeny;
    private static bool activateLower;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            activateLower = true;
        UpdateIfNeed();
        //Debug.Log("Lower active");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            activateLower = false;
        UpdateIfNeed();
        //Debug.Log("Lower unactive");
    }

    public static void UpdateIfNeed()
    {
        //TODO fix problem on climb down
        if (LadderObj.AllowUseLadder())
        {
            if (activateLower && !MiddleLadder.GetActivateStatus() && !UpperLadder.GetActivateStatus() ||
                !activateLower && MiddleLadder.GetActivateStatus() && !UpperLadder.GetActivateStatus() ||
                !activateLower && !MiddleLadder.GetActivateStatus() && UpperLadder.GetActivateStatus() )
                turnDeny = true;
            else
                turnDeny = false;
        }
    }

    public static bool DenyTurn()
    {
        return turnDeny;
    }
}

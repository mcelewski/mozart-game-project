using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterOrLeaveDungeon : MonoBehaviour
{
    public UserInteractListener listener;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        // send information about dungeon to enter
        // object(id), scene type
        // make autosave, player pos, player eq
        listener.EnableEnterHiddenObjectsScene = true;
        Debug.Log(this.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        listener.EnableEnterHiddenObjectsScene = false;
        Debug.Log("Leaved");
    }
}

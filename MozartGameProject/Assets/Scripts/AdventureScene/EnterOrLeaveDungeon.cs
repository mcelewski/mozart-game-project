using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterOrLeaveDungeon : MonoBehaviour
{
    public UserInteractListener listener;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        //TODO make autosave, player pos, player eq
        OnCanChangedScene(this.gameObject, true);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        OnCanChangedScene(this.gameObject, false);
    }

    private void OnCanChangedScene(GameObject sender, bool ready)
    {
        listener.AllowUserToChangeScene(sender,ready);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class EnterOrLeaveDungeon : MonoBehaviour
{
    public UserInteractListener listener;

    private Dictionary<string,GameObject> SpawnListDictionary = new Dictionary<string, GameObject>();
    
    private void Start()
    {
        if (!listener)
        {
            listener = GameObject.Find("PlayerBehaviour").GetComponent<UserInteractListener>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        //TODO make autosave, player pos, player eq, spawn 
        OnCanChangedScene(gameObject, true);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        OnCanChangedScene(gameObject, false);
    }
    
    private void OnCanChangedScene(GameObject sender, bool ready)
    {
        listener.AllowUserToChangeScene(sender,ready);
    }
}

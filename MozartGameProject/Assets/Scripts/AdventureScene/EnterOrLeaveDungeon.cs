using System.Collections.Generic;
using UnityEngine;

public class EnterOrLeaveDungeon : MonoBehaviour
{
    public UserInteractListener listener;

    void Start(){
        if (!listener)
            listener = GameObject.Find("PlayerBehaviour").GetComponent<UserInteractListener>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if (!IsPlayer(other)) return;
        //TODO make autosave, player pos, player eq, spawn 
        AllowToChangeScene(gameObject);
    }
    
    void OnTriggerExit2D(Collider2D other){
        if (!IsPlayer(other)) return;
        DenyToChangeScene(gameObject);
    }
    
    void AllowToChangeScene(GameObject sceneName) {
        Debug.Log("Player can change scene to "+ sceneName);
        SceneMovementController.AllowUserToChangeScene(sceneName,true);
    }
    
    void DenyToChangeScene(GameObject sceneName) {
        Debug.Log("Player **cannot** change scene to "+ sceneName);
        SceneMovementController.AllowUserToChangeScene(sceneName,false);
    }
    
    bool IsPlayer(Collider2D col) {
        return col.CompareTag("Player");
    }
    
    /*
     * public UserInteractListener listener;

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
     */
}

using System.Collections.Generic;
using UnityEngine;

public class EnterOrLeaveDungeon : MonoBehaviour
{
    public UserInteractListener listener;
    private static bool canChangeScene;

    void Start(){
        if (!listener)
            listener = GameObject.Find("PlayerBehaviour").GetComponent<UserInteractListener>();
    }

    void OnTriggerStay2D(Collider2D other){
        if (!IsPlayer(other)) return;
        //TODO make autosave, player pos, player eq, spawn 
        AllowToChangeScene(gameObject);
    }
    
    void OnTriggerExit2D(Collider2D other){
        if (!IsPlayer(other)) return;
        DenyToChangeScene(gameObject);
    }
      
    void AllowToChangeScene(GameObject sceneToLoad) {
        Debug.Log("Player can change scene to "+ sceneToLoad);
        SceneMovementController.SetSceneToLoad(sceneToLoad, false);
        canChangeScene = true;
    }
    
    void DenyToChangeScene(GameObject sceneToLoad) {
        Debug.Log("Player **cannot** change scene to "+ sceneToLoad);
        SceneMovementController.SetSceneToLoad(sceneToLoad, true);
        canChangeScene = false;
    }
    
    public static bool CanPlayerChangeScene()
    {
        return canChangeScene;
    }

    bool IsPlayer(Collider2D col) {
        return col.CompareTag("Player");
    }
}

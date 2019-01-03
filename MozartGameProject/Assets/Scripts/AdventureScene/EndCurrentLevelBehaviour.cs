using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCurrentLevelBehaviour : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!IsPlayer(other)) return;   
        
        
        //TODO autosave, show summary level, open keyboard scene
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(!IsPlayer(other)) return;
    }
    
    void AllowToChangeScene(GameObject sceneToLoad) {
        Debug.Log("Player can change scene to "+ sceneToLoad);
        SceneMovementController.SetSceneToLoad(sceneToLoad, false);
    }
    
    void DenyToChangeScene(GameObject sceneToLoad) {
        Debug.Log("Player **cannot** change scene to "+ sceneToLoad);
        SceneMovementController.SetSceneToLoad(sceneToLoad, true);
    }
    
    bool IsPlayer(Collider2D col) {
        return col.CompareTag("Player");
    }
}

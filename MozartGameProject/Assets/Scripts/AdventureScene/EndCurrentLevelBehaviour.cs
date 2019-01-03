using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCurrentLevelBehaviour : MonoBehaviour 
{
    //TODO autosave, show summary level, open keyboard scene
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!IsPlayer(other)) return;
        AllowToChangeScene(this.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(!IsPlayer(other)) return;
        DenyToChangeScene(this.gameObject);
    }
    
    void AllowToChangeScene(GameObject sceneToLoad) {
        Debug.Log("Player can leave current level");
        SceneMovementController.SetSceneToLoad(sceneToLoad, false);
    }
    
    void DenyToChangeScene(GameObject sceneToLoad) {
        Debug.Log("Player **cannot** leave current level");
        SceneMovementController.SetSceneToLoad(sceneToLoad, true);
    }
    
    bool IsPlayer(Collider2D col) {
        return col.CompareTag("Player");
    }
}

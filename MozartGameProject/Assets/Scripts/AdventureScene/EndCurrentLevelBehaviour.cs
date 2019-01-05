using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCurrentLevelBehaviour : MonoBehaviour 
{
    //TODO autosave, show summary level, open keyboard scene
    private static bool endScene;
    
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
        // endcene if all on adventure is done
        endScene = true;
    }
    
    void DenyToChangeScene(GameObject sceneToLoad) {
        Debug.Log("Player **cannot** leave current level");
        SceneMovementController.SetSceneToLoad(sceneToLoad, true);
        endScene = false;
    }
    
    public static bool CanPlayerChangeScene()
    {
        return endScene;
    }
    
    bool IsPlayer(Collider2D col) {
        return col.CompareTag("Player");
    }
}

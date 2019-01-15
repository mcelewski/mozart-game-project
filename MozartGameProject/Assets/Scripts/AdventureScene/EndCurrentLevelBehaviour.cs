using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCurrentLevelBehaviour : MonoBehaviour 
{
    //TODO autosave, show summary level
    private static bool endScene;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!IsPlayer(other)) return;
        AllowToEndScene();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(!IsPlayer(other)) return;
        DenyToEndScene();
    }
    
    void AllowToEndScene() {
        Debug.Log("Player can leave current level");
        endScene = true;
    }
    
    void DenyToEndScene() {
        Debug.Log("Player **cannot** leave current level");
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

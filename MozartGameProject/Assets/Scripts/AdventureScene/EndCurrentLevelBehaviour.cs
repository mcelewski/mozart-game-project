using UnityEngine;

public class EndCurrentLevelBehaviour : MonoBehaviour 
{
    //TODO autosave, show summary level
    static bool endScene;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!IsPlayer(other)) return;
        AllowToEndScene();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(!IsPlayer(other)) return;
        DenyToEndScene();
    }
    
    void AllowToEndScene() {
        //Debug.Log("Player can leave current level");
        endScene = true;
    }
    
    void DenyToEndScene() {
        //Debug.Log("Player **cannot** leave current level");
        endScene = false;
    }

    public static bool CanPlayerEndScene()
    {
        return endScene;
    }
    
    bool IsPlayer(Collider2D col) {
        return col.CompareTag("Player");
    }
}

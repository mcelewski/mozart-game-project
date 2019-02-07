using UnityEngine;

public class EnterOrLeaveDungeon : MonoBehaviour
{
    public UserInteractListener listener;
    static bool canChangeScene;
    public GameObject sceneToGo;

    void Start(){
        if (!listener || !sceneToGo)
        {
            listener = GameObject.Find("PlayerBehaviour").GetComponent<UserInteractListener>();
            sceneToGo = gameObject.transform.parent.gameObject;
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if (!IsPlayer(other)) return;
        //TODO make autosave, player pos, player eq, spawn 
        AllowToChangeScene(sceneToGo);
    }
    
    void OnTriggerExit2D(Collider2D other){
        if (!IsPlayer(other)) return;
        DenyToChangeScene(sceneToGo);
    }
      
    void AllowToChangeScene(GameObject sceneToLoad) {
        //Debug.Log("Player can change scene to "+ sceneToLoad);
        SceneMovementController.SetSceneToLoad(sceneToLoad, false);
        canChangeScene = true;
    }
    
    void DenyToChangeScene(GameObject sceneToLoad) {
        //Debug.Log("Player **cannot** change scene to "+ sceneToLoad);
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

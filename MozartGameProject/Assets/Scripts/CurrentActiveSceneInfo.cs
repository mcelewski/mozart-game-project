using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentActiveSceneInfo : MonoBehaviour 
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if(!other.CompareTag("Player")) return;
        
        SceneMovementController.SetCurrentlyActiveScene(SceneMovementController.ScenesInGame.HiddenObjects);
    }
}

using System;
using UnityEngine;

public class ActualSceneBehaviour : MonoBehaviour
{
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        SceneMovementController.SetCurrentSceneInfo(this.gameObject);
        
    }
}

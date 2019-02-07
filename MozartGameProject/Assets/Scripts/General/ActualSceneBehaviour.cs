using UnityEngine;

public class ActualSceneBehaviour : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        SceneMovementController.SetCurrentSceneInfo(this.gameObject);
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        SceneMovementController.SetCurrentSceneInfo(this.gameObject);
        
    }
}

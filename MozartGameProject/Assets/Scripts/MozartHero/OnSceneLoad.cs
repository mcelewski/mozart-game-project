using UnityEngine;

public class OnSceneLoad : MonoBehaviour
{
    private void OnEnable()
    {
        SceneMovementController.SetCurrentSceneInfo(this.gameObject);
    }
}

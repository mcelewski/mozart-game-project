using UnityEngine;

public class DeathZoneController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Note")) return;
        
        Debug.Log("Enter death zone");
    }

    void OnTriggerStay(Collider other)
    {
        if(!other.CompareTag("Note")) return;
        
        Debug.Log("In death zone");
    }

    void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Note")) return;
        // deactivate gameobject prefab
        Debug.Log("Over death zone");
    }
}

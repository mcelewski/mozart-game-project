using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Note")) return;
        
        Debug.Log("Enter death zone");
    }

    private void OnTriggerStay(Collider other)
    {
        if(!other.CompareTag("Note")) return;
        
        Debug.Log("In death zone");
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Note")) return;
        // deactivate gameobject prefab
        Debug.Log("Over death zone");
    }
}

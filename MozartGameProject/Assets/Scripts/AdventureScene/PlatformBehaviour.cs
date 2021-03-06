﻿using UnityEngine;
public class PlatformBehaviour : MonoBehaviour 
{
    public static bool SetPlayerTrigger { get; set; }

    static Collider2D _gameObjectCollider;

    void Start()
    {
        _gameObjectCollider = gameObject.GetComponent<Collider2D>();
        if (!gameObject.GetComponent<Collider2D>().isTrigger)
            gameObject.GetComponent<Collider2D>().isTrigger = true;
    }

    /// <summary>
    /// Detect if player moved into a platform and set trigger to false
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        SetPlayerTrigger = false;
    }

    /// <summary>
    /// Static function to change platform state if player enter ladder
    /// </summary>
    public static void SetPlatformTrigger(bool trigger)
    {
        _gameObjectCollider.isTrigger = trigger;
    }
}

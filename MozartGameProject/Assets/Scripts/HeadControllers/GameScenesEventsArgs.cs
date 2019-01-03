using System;
using UnityEngine;

public class GameScenesEventsArgs : EventArgs
{
    private GameObject _gameObject;
    
    public void OnGameScenesEventsArgs(GameObject gameObject)
    {
        this._gameObject = gameObject;
    }
}

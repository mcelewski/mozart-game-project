using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// knowledge about actual played scene
/// </summary>
public class SceneMovementController : MonoBehaviour 
{
    public enum SceneLoaded
    {
        Adventure,
        HiddenObjects,
        MozartHero
    }

    private SceneLoaded actualScene;

    private void Awake()
    {
        actualScene = SceneLoaded.Adventure;
    }

    public void SetActualLoadedScene(SceneLoaded sceneType)
    {
        GetSceneLoadedStatus = sceneType;
    }

    public SceneLoaded GetSceneLoadedStatus
    {
        get
        {
            return actualScene;
        }
        private set
        {
            actualScene = value;
        }
    }
}

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

    private static SceneLoaded actualScene;

    private void Awake()
    {
        actualScene = SceneLoaded.Adventure;
    }

    public static void SetActualLoadedScene(SceneLoaded sceneType)
    {
        GetSceneLoadedStatus = sceneType;
    }

    public static SceneLoaded GetSceneLoadedStatus
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

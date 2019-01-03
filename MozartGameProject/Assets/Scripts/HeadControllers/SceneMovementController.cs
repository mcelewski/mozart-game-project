using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// knowledge about actual played scene
/// </summary>
public class SceneMovementController : MonoBehaviour 
{
    public enum ScenesInGame
    {
        Adventure,
        HiddenObjects,
        MozartHero,
        Paused
    }
    
    private static string sceneToGoAfterEPress;
    private static string lastLoadedScene;
    public static ScenesInGame currentScene, sceneToGo;

    /// <summary>
    /// Set up scene info to load
    /// </summary>
    /// <param name="sceneToLoad"> GameObject based info like tag and name</param>
    /// <param name="clearData"> If disable scene to load clear data</param>
    public static void SetSceneToLoad(GameObject sceneToLoad, bool clearData)
    {
        if (!clearData)
            SetSceneToGoInfo(sceneToLoad);
    }
  
    /// <summary>
    /// Set new scene and check if all is right
    /// </summary>
    public void SetNewScene()
    {
        LoadScene();
    }
    
    public IEnumerator UnloadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.UnloadSceneAsync(lastLoadedScene);
    }
    
    /// <summary>
    /// Set up basic current scene info
    /// </summary>
    /// <param name="sceneInfo">Game object holding scene information</param>
    public static void SetCurrentSceneInfo(GameObject sceneInfo)
    {
        if (sceneInfo.CompareTag("Adventure"))
        {
            currentScene = ScenesInGame.Adventure;
        }
        else if (sceneInfo.CompareTag("HiddenObjects"))
        {
            currentScene = ScenesInGame.HiddenObjects;
        }
        else if (sceneInfo.CompareTag("MozartHero"))
        {
            currentScene = ScenesInGame.MozartHero;
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneToGoAfterEPress, LoadSceneMode.Additive);
        lastLoadedScene = sceneToGoAfterEPress;
    }
    
    public void BackToDefaultScene()
    {
        Debug.Log("DefaultScene");
        StartCoroutine(UnloadScene());
    }

    /// <summary>
    /// On Load scene run function to change scene place
    /// </summary>
    /// <param name="sceneInfo"></param>
    public static void SetCurrentlyActiveScene(ScenesInGame sceneInfo)
    {
        currentScene = sceneInfo;
        Debug.Log("set curent");
    }
    private IEnumerator CheckLoadedScene()
    {
        yield return new WaitForSeconds(3f);
        GameObject[] gameObjects = SceneManager.GetSceneByName(lastLoadedScene).GetRootGameObjects();
        if (gameObjects != null) Debug.Log("Scene not loaded");
    }

    /// <summary>
    /// Set up basic new scene info
    /// </summary>
    /// <param name="sceneInfo">Game object holding scene information</param>
    private static void SetSceneToGoInfo(GameObject sceneInfo)
    {
        sceneToGoAfterEPress = sceneInfo.name;
        
        if (sceneInfo.CompareTag("Adventure"))
        {
            sceneToGo = ScenesInGame.Adventure;
        }
        else if (sceneInfo.CompareTag("HiddenObjects"))
        {
            sceneToGo = ScenesInGame.HiddenObjects;
        }
        else if (sceneInfo.CompareTag("MozartHero"))
        {
            sceneToGo = ScenesInGame.MozartHero;
        }
    }
    /// <summary>
    /// Default setting: SceneInGame = Adventure, sceneToGoAfterEPress = "Adventure"
    /// </summary>
    private static void DefaultSceneInfo()
    {
        sceneToGoAfterEPress = "Adventure";
    }
    #region Check currnetly loaded scene type

    /// <summary>
    /// Check current playing scene
    /// </summary>
    /// <returns>True if is playing, otherwise false</returns>
    public bool IsPaused()
    {
        return currentScene == ScenesInGame.Paused ? true : false;
    }

    /// <summary>
    /// Check current playing scene
    /// </summary>
    /// <returns>True if is playing, otherwise false</returns>
    public bool IsOnMozartHeroScene()
    {
        return currentScene == ScenesInGame.MozartHero ? true : false;
    }
    
    /// <summary>
    /// Check current playing scene
    /// </summary>
    /// <returns>True if is playing, otherwise false</returns>
    public bool IsOnHiddenObjectsScene()
    {
        return currentScene == ScenesInGame.HiddenObjects ? true : false;
    }

    /// <summary>
    /// Check current playing scene
    /// </summary>
    /// <returns>True if is playing, otherwise false</returns>
    public bool IsOnAdventureScene()
    {
        if (currentScene == ScenesInGame.Adventure)
            return true;
        else
            return false;
    }

    //TODO puzzle
    #endregion
}

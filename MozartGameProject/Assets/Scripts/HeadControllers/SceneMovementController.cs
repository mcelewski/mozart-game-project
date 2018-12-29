using System.Collections;
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
            SetSceneInfo(sceneToLoad);
        else
            DefaultSceneInfo();
    }
  
    /// <summary>
    /// Set new scene and check if all is right
    /// </summary>
    public void SetNewScene()
    {
        LoadScene();
        StartCoroutine(CheckLoadedScene());
    }
    
    public IEnumerator UnloadScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.UnloadSceneAsync(lastLoadedScene);
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

    private IEnumerator CheckLoadedScene()
    {
        yield return new WaitForSeconds(7f);
        GameObject[] gameObjects = SceneManager.GetSceneByName(lastLoadedScene).GetRootGameObjects();
        //TODO problem with changing current scene
        currentScene = sceneToGo;
        if (gameObjects != null) Debug.Log("Scene not loaded");
    }

    /// <summary>
    /// Set up basic new scene info
    /// </summary>
    /// <param name="sceneInfo">Game object holding scene information</param>
    private static void SetSceneInfo(GameObject sceneInfo)
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
        currentScene = ScenesInGame.Adventure;
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

    #endregion
}

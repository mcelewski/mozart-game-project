using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// knowledge about actual played scene
/// </summary>
public class SceneMovementController : MonoBehaviour 
{
    public enum Scene
    {
        Adventure,
        HiddenObjects,
        MozartHero
    }
    
    public static string sceneToGoAfterEPress;
    
    public static Scene currentScene;


    public static void SetActualLoadedScene(Scene sceneType)
    {
        SceneManager.LoadSceneAsync(sceneToGoAfterEPress, LoadSceneMode.Additive);
        currentScene = sceneType;
    }
  
    public void SetNewScene()
    {
        SceneMovementController.SetActualLoadedScene(SceneMovementController.Scene.HiddenObjects);
        SceneManager.LoadSceneAsync(sceneToGoAfterEPress, LoadSceneMode.Additive);
        Debug.Log("e");
        StartCoroutine(CheckLoadedScene());
    }

    public static IEnumerator UnloadScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.UnloadSceneAsync(sceneToGoAfterEPress);
    }

    static IEnumerator CheckLoadedScene()
    {
        Debug.Log("in");
        yield return new WaitForSeconds(4f);
        GameObject[] gameObjects = SceneManager.GetSceneByName(sceneToGoAfterEPress).GetRootGameObjects();
        Debug.Log("leng: " + gameObjects.Length);
        foreach (var item in gameObjects)
        {
            Debug.Log("item: + " + item.name);
        }
        
    }

    public static void AllowUserToChangeScene(GameObject sender, bool ready)
    {
        /*AllowToLeaveDungeon = ready;
        EnableEnterDungeon = ready;
        SceneName = sender.name;*/
        sceneToGoAfterEPress = sender.name;
    }
}

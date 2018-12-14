using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Place where are defined all user actions in game
/// </summary>
public class UserInteractListener : MonoBehaviour
{
    //TODO Keyboard input for all scenes including pause menu
    public GameObject player;
    public GameObject MainMenuUI;
    public Dictionary<KeyCode, Action> ActionsDictionary = new Dictionary<KeyCode, Action>();

    public bool IsPaused { get; set; }
    public bool EnterToDungeon { get; set; }
    public bool EnternedAdventureScene { get; set; }
    public bool EnternedKeyboardScene { get; set; }

    public string SceneName { get; private set; }

    public bool EnableEnterHiddenObjectsScene { get; set; }

    private float mainSpeed = 5f;
    private float actionSpeed = 60;
    private float jumpHeigh = 40;
    
    private void Awake()
    {
        SetActionsToDictionary();
        IsPaused = false;
        EnternedKeyboardScene = false;
        EnterToDungeon = false;
        EnternedAdventureScene = true;
        EnableEnterHiddenObjectsScene = false;
    }

    public void TakeActionOnKeyPress()
    {
        SetMozartRigidbody();
        foreach (KeyCode key in ActionsDictionary.Keys)
        {
            if (Input.GetKey(key) && !EnternedKeyboardScene)
            {
                ActionsDictionary[key].Invoke();
            }
        }
    }
    
    private void SetActionsToDictionary()
    {
        if (ActionsDictionary.Count < 0)
            Debug.Log("Actions are empty");
        
        ActionsDictionary.Add(KeyCode.I, OpenEquipment);
        ActionsDictionary.Add(KeyCode.E, UseItem);
        ActionsDictionary.Add(KeyCode.A, MoveLeft);
        ActionsDictionary.Add(KeyCode.D, MoveRight);
        ActionsDictionary.Add(KeyCode.W, ClimbUp);
        ActionsDictionary.Add(KeyCode.S, ClimbDown);
        ActionsDictionary.Add(KeyCode.Space, Jump);
        ActionsDictionary.Add(KeyCode.Escape, OpenClosePauseMenu);
    }

    private void OpenClosePauseMenu()
    {
        if (!IsPaused)
        {
            MainMenuUI.GetComponent<MenuUIController>().EnableMenu();
            Time.timeScale = 0;
        }
    }

    #region PlayerMovement

    private void OpenEquipment()
    {
        Debug.Log("Equipment opened");
    }

    private void UseItem()
    {
        if (EnableEnterHiddenObjectsScene &&
             SceneMovementController.GetSceneLoadedStatus != SceneMovementController.SceneLoaded.HiddenObjects)
        {
            SetNewMozartRespawn();
            SetNewScene();
            DetectNewSpawnLocation();
            EnterToDungeon = true;
        }
        else if (!EnableEnterHiddenObjectsScene &&
            SceneMovementController.GetSceneLoadedStatus == SceneMovementController.SceneLoaded.HiddenObjects)
        {
            UnloadScene();
            EnterToDungeon = false;
        }

        Debug.Log("UseItem");
    }
    private void MoveLeft()
    {
        player.GetComponent<Rigidbody2D>().transform.position += Vector3.left * mainSpeed * Time.deltaTime; 
        player.GetComponent<SpriteRenderer>().flipX = false;
    }
    private void MoveRight()
    {
        player.GetComponent<Rigidbody2D>().transform.position += Vector3.right * mainSpeed * Time.deltaTime;
        player.GetComponent<SpriteRenderer>().flipX = true;
    }
    private void ClimbUp()
    {
        if (!EnterToDungeon && LadderObj.AllowUseLadder())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.up * mainSpeed * Time.deltaTime;
        }
        else if (EnterToDungeon)
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.up * mainSpeed * Time.deltaTime;
        }
        
    }
    private void ClimbDown()
    {
        if (!EnterToDungeon && LadderObj.AllowUseLadder())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.down * mainSpeed * Time.deltaTime;
        }
        else if (EnterToDungeon)
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.down * mainSpeed * Time.deltaTime;
        }
        
    }

    private void Jump()
    {
        if (!EnternedKeyboardScene && !EnterToDungeon && PlayerGroudDetection.IsGrounded())
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0,jumpHeigh * mainSpeed * Time.deltaTime,0) ;
        }
    }

    #endregion

    private void SetMozartRigidbody()
    {
        var rb = player.GetComponent<Rigidbody2D>();
        if (LadderObj.AllowUseLadder() || EnterToDungeon)
        {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }
    
    private void DetectNewSpawnLocation()
    {
        Debug.Log("sc" + SceneName);
    }

    private void SetNewMozartRespawn()
    {
        var respawnObj = new GameObject("RespawnAfterDungeon");
        respawnObj.transform.position = player.transform.position;
        respawnObj.tag = "Respawn";
        if (SceneMovementController.GetSceneLoadedStatus == SceneMovementController.SceneLoaded.HiddenObjects)
        {
            Instantiate(respawnObj);
        }
    }

    private void SetNewScene()
    {
        Scene scene = SceneManager.GetSceneByName(SceneName);
        Debug.Log("name: " + scene.name + " ,namepath: " + SceneName );
        SceneMovementController.SetActualLoadedScene(SceneMovementController.SceneLoaded.HiddenObjects);
        SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(scene);
    }

    private void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(SceneName);
    }

    public void AllowUserToChangeScene(GameObject sender, bool ready)
    {
        EnableEnterHiddenObjectsScene = ready;
        SceneName = sender.name;
    }
}

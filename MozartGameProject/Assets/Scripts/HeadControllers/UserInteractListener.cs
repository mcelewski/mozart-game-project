using System;
using System.Collections.Generic;
using System.Linq;
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
        if (IsPaused)
        {
            MainMenuUI.GetComponent<MenuUIController>().EnableMenu();
        }
        MainMenuUI.GetComponent<MenuUIController>().DisableMenu();
    }

    private void OpenEquipment()
    {
        Debug.Log("Equipment opened");
    }

    private void UseItem()
    {
        if (EnableEnterHiddenObjectsScene &&
             SceneMovementController.GetSceneLoadedStatus != SceneMovementController.SceneLoaded.HiddenObjects)
        {
            SceneMovementController.SetActualLoadedScene(SceneMovementController.SceneLoaded.HiddenObjects);
            SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
            SetMozartRigidbody(false);
            SpawnMozartOnOtherPlace();
            EnterToDungeon = true;
        }
        else if (!EnableEnterHiddenObjectsScene &&
            SceneMovementController.GetSceneLoadedStatus == SceneMovementController.SceneLoaded.HiddenObjects)
        {
            Debug.Log("You can leave");
            SetMozartRigidbody(true);
            SceneManager.UnloadSceneAsync(SceneName);
        }

        Debug.Log("UseItem");
    }
    private void MoveLeft()
    {
        player.GetComponent<Transform>().transform.position += Vector3.left * mainSpeed * Time.deltaTime;
        player.GetComponent<SpriteRenderer>().flipX = false;
    }
    private void MoveRight()
    {
        player.GetComponent<Transform>().transform.position += Vector3.right * mainSpeed * Time.deltaTime;
        player.GetComponent<SpriteRenderer>().flipX = true;
    }
    private void ClimbUp()
    {
        if (!EnterToDungeon && LadderObj.AllowUseLadder())
        {
            SetMozartRigidbody(false);
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0,actionSpeed * mainSpeed * Time.deltaTime, 0);
        }
        else if (EnterToDungeon)
        {
            player.GetComponent<Transform>().transform.position += Vector3.up * mainSpeed * Time.deltaTime;
        }
        else if (!LadderObj.AllowUseLadder())
        SetMozartRigidbody(true);
    }
    private void ClimbDown()
    {
        if (!EnterToDungeon && LadderObj.AllowUseLadder())
        {
            SetMozartRigidbody(false);
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-actionSpeed * mainSpeed * Time.deltaTime, 0);
        }
        else if (EnterToDungeon)
        {
            player.GetComponent<Transform>().transform.position += Vector3.down * mainSpeed * Time.deltaTime;
        }
        else if (!LadderObj.AllowUseLadder())
            SetMozartRigidbody(true);
        
    }

    private void Jump()
    {
        if (!EnternedKeyboardScene && !EnterToDungeon && PlayerGroudDetection.IsGrounded())
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0,actionSpeed * mainSpeed * Time.deltaTime,0) ;
        }
    }

    private void SetMozartRigidbody(bool set)
    {
        var rb = player.GetComponent<Rigidbody2D>();
        rb.simulated = set;
    }

    private void SpawnMozartOnOtherPlace()
    {
        GameObject[] hObjects = SceneManager.GetSceneByName(SceneName).GetRootGameObjects();
        
        foreach (var item in hObjects)
        {
            Debug.Log("in" + item);
            if (item.CompareTag("Spawn"))
            {
                player.transform.position += item.GetComponent<Transform>().transform.position;
                Debug.Log("Found");
            }
        }
    }

    public void AllowUserToChangeScene(GameObject sender, bool ready)
    {
        EnableEnterHiddenObjectsScene = ready;
        SceneName = sender.name;
    }

    
}

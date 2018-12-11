using System;
using System.Collections.Generic;
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
    public bool EnternedHiddenObjectsScene { get; set; }
    public bool EnternedAdventureScene { get; set; }
    public bool EnternedKeyboardScene { get; set; }

    public string SceneName { get; private set; }

    public bool EnableEnterHiddenObjectsScene { get; set; }

    private float mainSpeed = 5f;
    
    private void Awake()
    {
        SetActionsToDictionary();
        IsPaused = false;
        EnternedKeyboardScene = false;
        EnternedHiddenObjectsScene = false;
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
            SceneManager.LoadScene(SceneName);
            SetMozartRigidbody(false);
        }
        Debug.Log("UseItem");
    }
    private void MoveLeft()
    {
        player.GetComponent<Transform>().transform.position += Vector3.left * mainSpeed * Time.deltaTime;
    }
    private void MoveRight()
    {
        player.GetComponent<Transform>().transform.position += Vector3.right * mainSpeed * Time.deltaTime;
    }
    private void ClimbUp()
    {
        if (!EnternedHiddenObjectsScene)
        {
            player.GetComponent<Rigidbody2D>().velocity += new Vector2(0,1 * mainSpeed * Time.deltaTime);
        }
        else
        {
            player.GetComponent<Transform>().transform.position += Vector3.up * mainSpeed * Time.deltaTime;
        }
        Debug.Log("ClimbUp");
    }
    private void ClimbDown()
    {
        if (!EnternedHiddenObjectsScene)
        {
            player.GetComponent<Rigidbody2D>().velocity += new Vector2(0,-1 * mainSpeed * Time.deltaTime);
        }
        else
        {
            player.GetComponent<Transform>().transform.position += Vector3.down * mainSpeed * Time.deltaTime;
        }
        Debug.Log("ClimbDown");
    }

    private void Jump()
    {
        //TODO If grounded enable jump else do nothing
        if (!EnternedKeyboardScene && !EnternedKeyboardScene && PlayerGroudDetection.IsGroundedAlready())
        {
            player.GetComponent<Transform>().transform.position += Vector3.up * mainSpeed * Time.deltaTime;
        }
    }

    private void SetMozartRigidbody(bool set)
    {
        var rb = player.GetComponent<Rigidbody2D>();

        if (set == false)
            rb.gravityScale = 0;
        rb.gravityScale = 1;
    }

    public void AllowUserToChangeScene(GameObject sender, bool ready)
    {
        EnableEnterHiddenObjectsScene = ready;
        SceneName = sender.name;
    }

   
}

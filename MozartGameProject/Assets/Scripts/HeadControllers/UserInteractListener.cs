using System;
using System.Collections;
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
    public GameObject hiddenSceneSpawnPref;
    public Dictionary<KeyCode, Action> ActionsDictionary = new Dictionary<KeyCode, Action>();

    public bool IsPaused { get; set; }
    public bool EnterToDungeon { get; set; }
    public bool EnternedKeyboardScene { get; set; }
    public bool AllowToTurn { get; private set; }
    public bool AllowToLeaveDungeon { get; set; }

    public bool EnableEnterDungeon { get; set; }

    private Transform respawn;
    private float mainSpeed = 5f;
    private float jumpHeigh = 40;
    
    private void Awake()
    {
        SetActionsToDictionary();
        IsPaused = false;
        EnternedKeyboardScene = false;
        EnterToDungeon = false;
        AllowToLeaveDungeon = false;
        AllowToTurn = true;
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
        if (EnableEnterDungeon &&
             IsOnHiddenObjectsScene())
        {
            SetNewMozartRespawn();
            SpawnToHiddenScene();
            SetMozartRigidbody();
            EnterToDungeon = true;
            EnableEnterDungeon = false;
        }
        if (AllowToLeaveDungeon && IsOnHiddenObjectsScene())
        {
            RespawnMozartToAdventure();
            StartCoroutine(SceneMovementController.UnloadScene());
            EnterToDungeon = false;
            EnableEnterDungeon = true;
        }

        Debug.Log("UseItem");
    }

    private static bool IsOnHiddenObjectsScene()
    {
        return SceneMovementController.currentScene != SceneMovementController.Scene.HiddenObjects;
    }

    private void MoveLeft()
    {
        if (AllowToTurn)
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.left * mainSpeed * Time.deltaTime; 
            player.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    private void MoveRight()
    {
        if (AllowToTurn)
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.right * mainSpeed * Time.deltaTime;
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
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

    #region Spawn

    private void SpawnToHiddenScene()
    {
        player.transform.position = hiddenSceneSpawnPref.transform.position;
    }

    private void SetNewMozartRespawn()
    {
        var respawnObj = new GameObject("RespawnAfterDungeon");
        respawnObj.transform.position = new Vector3(player.transform.position.x + 2, player.transform.position.y, player.transform.position.z);
        respawnObj.tag = "Respawn";
        if (IsOnHiddenObjectsScene())
        {
            Instantiate(respawnObj);
        }
        respawn = GameObject.Find(respawnObj.name).GetComponent<Transform>();
    }

    private void RespawnMozartToAdventure()
    {
        player.transform.position = respawn.transform.position;
    }

    #endregion

    
    
    
}

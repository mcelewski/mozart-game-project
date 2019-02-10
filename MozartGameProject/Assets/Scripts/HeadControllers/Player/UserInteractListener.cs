using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Place where are defined all user actions in game
/// </summary>
public class UserInteractListener : MonoBehaviour
{
    public GameObject player;
    public GameObject MainMenuUI;
    public Dictionary<KeyCode, Action> ActionsDictionary = new Dictionary<KeyCode, Action>();
    public SceneMovementController _sceneController;
    public RespawnBehaviour _spawnController;
    public InventoryDesign _inventoryDesign;
    public EndLevelUIController EndLevelUI;
    public PlayerLifeTime playerLifeTime;

    [SerializeField]float mainSpeed = 5.0f;
    [SerializeField]float jumpHeigh = 50.0f;
    
    void Awake()
    {
        SetActionsToDictionary();
    }

    public void TakeActionOnKeyPress()
    {
        SetMozartRigidbody();
        //Print();
        
        foreach (KeyCode key in ActionsDictionary.Keys)
        {
            if (Input.GetKey(key) && !_sceneController.IsOnMozartHeroScene() && !playerLifeTime.IsDead())
            {
                ActionsDictionary[key].Invoke();
            }
            else if (Input.GetKeyUp(key) && PlayerMove.currentPlayerAction == PlayerMove.PlayerStates.Climbing && !playerLifeTime.IsDead())
            {
                PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.ClimbingIdle;
            }
            else if (Input.GetKeyUp(key)&& !playerLifeTime.IsDead())
            {
                PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Idle;
            }
        }
    }
    
    void SetActionsToDictionary()
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

    void OpenClosePauseMenu()
    {
        if (!_sceneController.IsPaused())
        {
            MainMenuUI.GetComponent<MenuUIController>().EnableMenu();
        }
    }

    #region PlayerMovement

    void OpenEquipment()
    {
        if (!_sceneController.IsOnMozartHeroScene())
        {
            _inventoryDesign.OpenCloseInventory();
        }
    }

    void UseItem()
    {
        if (_sceneController.IsOnAdventureScene() && EnterOrLeaveDungeon.CanPlayerChangeScene())
        {
            _sceneController.SetNewScene();
            _spawnController.SetUpNewRespawn();
            _spawnController.SpawnToHiddenScene();
        }
        else if (_sceneController.IsOnHiddenObjectsScene() && EnterOrLeaveDungeon.CanPlayerChangeScene())
        {
            _spawnController.SpawnToAdventure();
            StartCoroutine(_spawnController.DeactivateSpawn());
            StartCoroutine(_sceneController.UnloadScene());
        }
        else if (_sceneController.IsOnAdventureScene() && EndCurrentLevelBehaviour.CanPlayerEndScene())
        {
            EndLevelUI.EnableEndMenu();
        }
        else if(_sceneController.IsOnAdventureScene() && AllowToPickUpItem.AllowToPickUp())
        {
            _inventoryDesign.AddToInventory();
        }
        else if (_sceneController.IsOnAdventureScene())
        {
            Debug.Log("Use item");
        }
    }

    void MoveLeft()
    {
        if (!LowerLadder.DenyTurn())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.left * mainSpeed * Time.deltaTime;
            player.GetComponent<SpriteRenderer>().flipX = false;
            PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Walking;
        }
    }
    void MoveRight()
    {
        if (!LowerLadder.DenyTurn())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.right * mainSpeed * Time.deltaTime;
            player.GetComponent<SpriteRenderer>().flipX = true;
            PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Walking;
        }
        
    }
    void ClimbUp()
    {
        if (!_sceneController.IsOnHiddenObjectsScene() && LadderObj.AllowUseLadder())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.up * mainSpeed * Time.deltaTime;
            PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Climbing;
        }
        else if (_sceneController.IsOnHiddenObjectsScene())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.up * mainSpeed * Time.deltaTime;
        }
    }
    
    void ClimbDown()
    {
        if (!_sceneController.IsOnHiddenObjectsScene() && LadderObj.AllowUseLadder())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.down * mainSpeed * Time.deltaTime;
            PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Climbing;
        }
        else if (_sceneController.IsOnHiddenObjectsScene())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.down * mainSpeed * Time.deltaTime;
        }
    }

    void Jump()
    {
        if (!_sceneController.IsOnMozartHeroScene() && !_sceneController.IsOnHiddenObjectsScene() && PlayerGroudDetection.IsGrounded())
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0,jumpHeigh * mainSpeed * Time.deltaTime,0) ;
            PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Jumping;
        }
    }

    #endregion

    void SetMozartRigidbody()
    {
        var rb = player.GetComponent<Rigidbody2D>();
        if (LadderObj.AllowUseLadder() || _sceneController.IsOnHiddenObjectsScene())
        {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    void Print()
    {
        Debug.Log("Scene to go + " + SceneMovementController.sceneToGo);
        Debug.Log("Adventure scene + " + _sceneController.IsOnAdventureScene());
        Debug.Log("Scene to go + " + SceneMovementController.sceneToGo);
        Debug.Log("Current scene: " + SceneMovementController.currentScene);
    }
}

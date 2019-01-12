﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

/// <summary>
/// Place where are defined all user actions in game
/// </summary>
public class UserInteractListener : MonoBehaviour
{
    public GameObject player;
    public GameObject MainMenuUI;
    public Dictionary<KeyCode, Action> ActionsDictionary = new Dictionary<KeyCode, Action>();
    public Animator animator;

    public SceneMovementController _sceneController;
    public RespawnBehaviour _spawnController;
    public InventorySpace _inventory;

    private float mainSpeed = 5.0f;
    private float jumpHeigh = 20.0f;
    
    private void Awake()
    {
        SetActionsToDictionary();
    }

    public void TakeActionOnKeyPress()
    {
        SetMozartRigidbody();
        //Debug.Log("Scene to go + " + SceneMovementController.sceneToGo);
        //Debug.Log("Adventure scene + " + _sceneController.IsOnAdventureScene());
        //Debug.Log("Scene to go + " + SceneMovementController.sceneToGo);
        //Debug.Log("Current scene: " + SceneMovementController.currentScene);
        foreach (KeyCode key in ActionsDictionary.Keys)
        {
            if (Input.GetKey(key) && !_sceneController.IsOnMozartHeroScene())
            {
                ActionsDictionary[key].Invoke();
            }
            else if (Input.GetKeyUp(key) && PlayerMove.currentPlayerAction == PlayerMove.PlayerStates.Walking)
            {
                EndMovingAnimation();
                PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Idle;
            }
            else if (Input.GetKeyUp(key) && PlayerMove.currentPlayerAction == PlayerMove.PlayerStates.Jumping)
            {
                EndJumpingAnimation();
                PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Idle;
            }
            else if (Input.GetKeyUp(key) && PlayerMove.currentPlayerAction == PlayerMove.PlayerStates.Climbing)
            {
                EndClimbingAnimation();
                PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Idle;
            }
            
            PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Idle;
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
        if (!_sceneController.IsPaused())
        {
            MainMenuUI.GetComponent<MenuUIController>().EnableMenu();
        }
    }

    #region PlayerMovement

    private void OpenEquipment()
    {
        if (!_sceneController.IsOnMozartHeroScene())
        {
            Debug.Log("Equipment opened");
        }
    }

    private void UseItem()
    {
        if (_sceneController.IsOnAdventureScene() && EnterOrLeaveDungeon.CanPlayerChangeScene())
        {
            _sceneController.SetNewScene();
            _spawnController.SetUpNewRespawn();
            _spawnController.SpawnToHiddenScene();
            Debug.Log("Enter dungeon");
        }
        else if (_sceneController.IsOnHiddenObjectsScene() && EnterOrLeaveDungeon.CanPlayerChangeScene())
        {
            _spawnController.SpawnToAdventure();
            StartCoroutine(_spawnController.DeactivateSpawn());
            StartCoroutine(_sceneController.UnloadScene());
            
            Debug.Log("Leave Dungeon");
        }
        else if (_sceneController.IsOnAdventureScene() && EndCurrentLevelBehaviour.CanPlayerChangeScene())
        {
            _sceneController.SetNewScene();
            Debug.Log("Mozart hero");
        }
        else if(AllowToPickUpItem.AllowToPickUp() && _sceneController.IsOnAdventureScene())
        {
            _inventory.AddToInventory(AllowToPickUpItem.ItemID());
            Debug.Log("Pick up to inventory");
        }
        else if (_sceneController.IsOnAdventureScene())
        {
            Debug.Log("Use item");
        }
    }

    private void MoveLeft()
    {
        if (!LowerLadder.DenyTurn())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.left * mainSpeed * Time.deltaTime;
            player.GetComponent<SpriteRenderer>().flipX = false;
            PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Walking;
            StartMovingAnimation();
        }
    }
    private void MoveRight()
    {
        if (!LowerLadder.DenyTurn())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.right * mainSpeed * Time.deltaTime;
            player.GetComponent<SpriteRenderer>().flipX = true;
            PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Walking;
            StartMovingAnimation();
        }
        
    }
    private void ClimbUp()
    {
        if (!_sceneController.IsOnHiddenObjectsScene() && LadderObj.AllowUseLadder())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.up * mainSpeed * Time.deltaTime;
            PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Climbing;
            StartClimbingAnimation();
        }
        else if (_sceneController.IsOnHiddenObjectsScene())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.up * mainSpeed * Time.deltaTime;
        }
    }
    
    private void ClimbDown()
    {
        if (!_sceneController.IsOnHiddenObjectsScene() && LadderObj.AllowUseLadder())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.down * mainSpeed * Time.deltaTime;
            PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Climbing;
            StartClimbingAnimation();
        }
        else if (_sceneController.IsOnHiddenObjectsScene())
        {
            player.GetComponent<Rigidbody2D>().transform.position += Vector3.down * mainSpeed * Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (!_sceneController.IsOnMozartHeroScene() && !_sceneController.IsOnHiddenObjectsScene() && PlayerGroudDetection.IsGrounded())
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0,jumpHeigh * mainSpeed * Time.deltaTime,0) ;
            PlayerMove.currentPlayerAction = PlayerMove.PlayerStates.Jumping;
            StartJumpingAnimation();
        }
    }

    #endregion

    private void SetMozartRigidbody()
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

    #region Moving animations
    
    private void EndMovingAnimation()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mozart_walk"))
        {
            animator.ResetTrigger("Mozart_Move");
        }
    }

    private void StartMovingAnimation()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mozart_idle"))
        {
            animator.SetTrigger("Mozart_Move");
        }
    }
    #endregion

    #region Jumping animations

    private void EndJumpingAnimation()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mozart_jump"))
        {
            animator.ResetTrigger("Mozart_Jump");
        }
    }

    private void StartJumpingAnimation()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mozart_idle"))
        {
            animator.SetTrigger("Mozart_Jump");
        }
    }

    #endregion
    
    #region Climbing animations

    private void EndClimbingAnimation()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mozart_climbing"))
        {
            animator.ResetTrigger("Mozart_Climb");
        }
    }

    private void StartClimbingAnimation()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mozart_idle"))
        {
            animator.SetTrigger("Mozart_Climb");
        }
    }

    #endregion
}

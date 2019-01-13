using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;

///<summary>
///My publisher
/// </summary>
public class PlayerMove : MonoBehaviour
{
    public UserInteractListener userAction;
    public SceneMovementController sceneController;
    public HealthBarBehaviour healthBar;
    public PlayerAnimations userAnimation;
    
    public static PlayerStates currentPlayerAction = PlayerStates.Idle;
    
    public enum PlayerStates
    {
        Idle,
        Walking,
        Jumping,
        Climbing,
        Torch
    }
    //TODO Keyboard input for all scenes including pause menu
    private void Update()
    {
        if (!sceneController.IsOnMozartHeroScene() && !sceneController.IsPaused())
        {
            userAction.TakeActionOnKeyPress();
            healthBar.CheckPoison();
            DetectAnimationToPlay();
        }
        else if (sceneController.IsOnMozartHeroScene() && !sceneController.IsPaused())
        {
            // mozart hero
        }
    }

    private void UpdateIfMozartHero()
    {
        // change settings for mozart hero scene
    }

    void DetectAnimationToPlay()
    {
        if (currentPlayerAction == PlayerStates.Idle)
        {
            userAnimation.EndClimbAnimation();
            userAnimation.EndJumpAnimation();
            userAnimation.EndMoveAnimation();
            userAnimation.EndTorchAnimation();
            Debug.Log("endanim");
        }
        else if (currentPlayerAction == PlayerStates.Walking)
        {
            userAnimation.StartMoveAnimation();
            Debug.Log("move");
        }
        else if (currentPlayerAction == PlayerStates.Jumping)
        {
            userAnimation.StartJumpAnimation();
            Debug.Log("jump");
        }
        else if (currentPlayerAction == PlayerStates.Climbing)
        {
            userAnimation.StartClimbAnimation();
            Debug.Log("climb");
        }
        else if (currentPlayerAction == PlayerStates.Torch)
        {
            userAnimation.StartTorchAnimation();
            Debug.Log("torch");
        }
    }
}

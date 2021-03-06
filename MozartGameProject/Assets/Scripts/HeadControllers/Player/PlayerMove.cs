﻿using UnityEngine;

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
        ClimbingIdle,
        Torch
    }
    //TODO Keyboard input for all scenes including pause menu
    void Update()
    {
        if (!sceneController.IsPaused())
        {
            userAction.TakeActionOnKeyPress();
            healthBar.CheckPoison();
            DetectAnimationToPlay();
        }
    }

    void DetectAnimationToPlay()
    {
        if (currentPlayerAction == PlayerStates.Idle)
        {
            userAnimation.StartIdleAnimation();
            userAnimation.EndClimbAnimation();
            userAnimation.EndJumpAnimation();
            userAnimation.EndMoveAnimation();
            userAnimation.EndLadderIdleAnimation();
        }
        else if (currentPlayerAction == PlayerStates.Walking)
        {
            userAnimation.StartMoveAnimation();
            userAnimation.EndJumpAnimation();
            userAnimation.EndClimbAnimation();
            userAnimation.EndIdleAnimation();
            userAnimation.EndLadderIdleAnimation();
        }
        else if (currentPlayerAction == PlayerStates.Jumping)
        {
            userAnimation.StartJumpAnimation();
            userAnimation.EndMoveAnimation();
            userAnimation.EndClimbAnimation();
            userAnimation.EndIdleAnimation();
            userAnimation.EndLadderIdleAnimation();
        }
        else if (currentPlayerAction == PlayerStates.Climbing)
        {
            userAnimation.StartClimbAnimation();
            userAnimation.EndIdleAnimation();
            userAnimation.EndMoveAnimation();
            userAnimation.EndTorchAnimation();
            userAnimation.EndLadderIdleAnimation();
        }
        else if (currentPlayerAction == PlayerStates.ClimbingIdle)
        {
            userAnimation.EndClimbAnimation();
            userAnimation.StartLadderIdleAnimation();
        }
        else if (currentPlayerAction == PlayerStates.Torch)
        {
            userAnimation.StartTorchAnimation();
            userAnimation.EndLadderIdleAnimation();
            userAnimation.EndIdleAnimation();
            userAnimation.EndMoveAnimation();
            userAnimation.EndTorchAnimation();
        }
    }
}

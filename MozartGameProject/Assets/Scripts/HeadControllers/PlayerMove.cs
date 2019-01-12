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
    
    public static PlayerStates currentPlayerAction = PlayerStates.Idle;
    
    public enum PlayerStates
    {
        Idle,
        Walking,
        Jumping,
        Climbing
    }
    //TODO Keyboard input for all scenes including pause menu
    private void Update()
    {
        if (!sceneController.IsOnMozartHeroScene() && !sceneController.IsPaused())
        {
            userAction.TakeActionOnKeyPress();
            healthBar.CheckPoison();
        }
        else if (sceneController.IsOnMozartHeroScene() && !sceneController.IsPaused())
        {
            // mozart hero
        }
    }

    private void UpdateIfNeed()
    {
        // change settings for mozart hero scene
    }
}

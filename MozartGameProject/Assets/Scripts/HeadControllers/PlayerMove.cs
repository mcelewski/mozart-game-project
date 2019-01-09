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
    //TODO Keyboard input for all scenes including pause menu
    private void Update()
    {
        if (!sceneController.IsOnMozartHeroScene())
        {
            userAction.TakeActionOnKeyPress();
            healthBar.CheckPoison();
        }
        else if (sceneController.IsOnMozartHeroScene())
        {
            // mozart hero
        }
    }

    private void UpdateIfNeed()
    {
        // change settings for mozart hero scene
    }
}

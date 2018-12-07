using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Place where are defined all user actions in game
/// </summary>
public class UserInteractListener : MonoBehaviour
{
    //TODO Keyboard input for all scenes including pause menu
    public GameObject player;
    public GameObject MainMenuUI;
    public Camera mainCamera;
    public Dictionary<KeyCode, Action> ActionsDictionary = new Dictionary<KeyCode, Action>();

    public bool IsPaused { get; set; }

    private float mainSpeed = 5f;
    
    private void Awake()
    {
        SetActionsToDictionary();
        IsPaused = false;
    }

    public void TakeActionOnKeyPress()
    {
        foreach (KeyCode key in ActionsDictionary.Keys)
        {
            if (Input.GetKey(key))
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

    private static void OpenEquipment()
    {
        Debug.Log("Equipment opened");
    }
    private static void UseItem()
    {
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
        player.GetComponent<Rigidbody2D>().velocity += new Vector2(0,1 * mainSpeed * Time.deltaTime);
        Debug.Log("ClimbUp");
    }
    private void ClimbDown()
    {
        player.GetComponent<Rigidbody2D>().velocity += new Vector2(0,-1 * mainSpeed * Time.deltaTime);
        Debug.Log("ClimbDown");
    }

    private void Jump()
    {
        //TODO If grounded enable jump else do nothing
        if (player.GetComponentInChildren<Collider2D>())
        {
            player.GetComponent<Transform>().transform.position += Vector3.up * mainSpeed * Time.deltaTime;
        }
        Debug.Log("Jump");
    }
}

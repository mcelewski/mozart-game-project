﻿using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PC keyboard:
///     Get elemnts from scene,
///     Assign to them keycode,
///     Play different sount depend on keycode
/// </summary>
/// 
public class KeyboardController : MonoBehaviour
{
    public List<GameObject> keyboardObjects;
    public List<KeyCode> keysCodes = new List<KeyCode>();
    // 1st string nazwa klawisza 2nd gameobject z przypisanym juz dzwiekiem
    public Dictionary<KeyCode, GameObject> noteKeys = new Dictionary<KeyCode, GameObject>();

    void Start()
    {
        for (int i = 0; i < keyboardObjects.Capacity; i++)
        {
            noteKeys.Add(keysCodes[i], keyboardObjects[i]);
        }
        if (noteKeys == null)
        {
            Debug.Log("Something went wrong:");
        }
    }
    public void DetectKey()
    {
        foreach (var key in keysCodes)
        {
            var singleNote = noteKeys[key].GetComponent<NoteIndicatorKeys>();
            if (Input.GetKeyDown(key))
            {
                singleNote.PlaySoundOnPress(NoteIndicatorKeys.KeyState.Down);
                singleNote.SetKeyState(NoteIndicatorKeys.KeyState.Down);
                singleNote.SetProperColor();
            }
            if (Input.GetKeyUp(key))
            {
                singleNote.SetKeyState(NoteIndicatorKeys.KeyState.Up);
                singleNote.SetProperColor();
            }
        }
    }

    public void KeyDown(out bool down)
    {
        foreach (var key in keysCodes)
        {
            if (Input.GetKeyDown(key))
                down = true;
            Debug.Log("if");
        }
        down = false;
    }
    
    public void KeyUp(out bool up)
    {
        foreach (var key in keysCodes)
        {
            if (Input.GetKeyUp(key))
                up = true;
            Debug.Log("if");
        }
        up = false;
    }
}
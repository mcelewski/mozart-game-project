using UnityEngine;
using MidiJack;
using System;

[RequireComponent(typeof(AudioSource))]
public class NoteIndicatorKeys : MonoBehaviour
{
    public int noteNumber;
    public bool isWhite;
    public AudioSource audioSource;
    public KeyState keyState = KeyState.Up;

    public enum KeyState
    {
        Up, Down, Pressed
    }

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        UpdateKeyState();
    }

    void UpdateKeyState()
    {
        if (WasJustReleased())
        {
            keyState = KeyState.Up;
            SetProperColor();
            PlaySoundOnPress();
        }
        if (WasJustPressed())
        {
            keyState = KeyState.Down;
            SetProperColor();
            PlaySoundOnPress();
        }
    }

    private bool WasJustReleased()
    {
        return MidiMaster.GetKeyUp(noteNumber) || MidiMaster.GetKey(noteNumber) < 0.01f;
    }

    private bool WasJustPressed()
    {
        if (MidiMaster.GetKey(noteNumber) > 0.5f && keyState == KeyState.Up)
            return true;
        return MidiMaster.GetKeyDown(noteNumber);
    }

    void PlaySoundOnPress()
    {
        if (keyState == KeyState.Down)
        {
            audioSource.Play(0);
            Debug.Log("GetKeyDown");
        }
    }

    void SetProperColor()
    {
        Color color;
        if (!isWhite)
            color = (keyState == KeyState.Down) ? Color.red : Color.black;
        else
            color = (keyState == KeyState.Down) ? Color.red : Color.white;
        GetComponent<Renderer>().material.color = color;
    }


}
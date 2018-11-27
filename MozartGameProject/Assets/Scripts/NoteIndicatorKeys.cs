using UnityEngine;
using MidiJack;
using System;
using UnityEngine.Experimental.UIElements;

/// <summary>
/// MIDI Keyboard controller
///     Detecting midi keys pressed, released, holded
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class NoteIndicatorKeys : MonoBehaviour
{
    public NoteActivated noteActivate;
    
    public int noteNumber;
    public bool isWhite;
    public AudioSource audioSource;
    public KeyState keyState = KeyState.Up;

    public enum KeyState
    {
        Up, Down,
    }

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        noteActivate = GameObject.FindGameObjectWithTag("Finish").GetComponent<NoteActivated>();
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
            PlaySoundOnPress(keyState);
        }
        if (WasPres())
        {
            keyState = KeyState.Down;
            SetProperColor();
            PlaySoundOnPress(keyState);
        }
    }

    private bool WasJustReleased()
    {
        return MidiMaster.GetKeyUp(noteNumber); //  || MidiMaster.GetKey(noteNumber) < 0.01f
    }

    private bool WasJustPressed()
    {
        if (MidiMaster.GetKey(noteNumber) > 0.5f && keyState == KeyState.Up)
            return true;
        return MidiMaster.GetKeyDown(noteNumber);
    }

    private bool WasPres()
    {
        return MidiMaster.GetKeyDown(noteNumber);
    }

    public void PlaySoundOnPress(KeyState key)
    {
        if (key == KeyState.Down)
        {
            OnChangeNoteStatus();
            audioSource.Play(0);
        }
    }

    private void SetProperColor()
    {
        Color color;
        if (!isWhite)
            color = (keyState == KeyState.Down) ? Color.red : Color.black;
        else
            color = (keyState == KeyState.Down) ? Color.red : Color.white;
        GetComponent<Renderer>().material.color = color;
    }

    public int GetNoteNumber
    {
        get { return noteNumber; }
    }

    public float GetXNotePosition()
    {
        return this.gameObject.transform.position.x;
    }

    private void OnChangeNoteStatus()
    {
        noteActivate.Number = GetNoteNumber;
    }

    public bool IsWhiteKeyboard
    {
        get { return isWhite; }
    }
}
using UnityEngine;
using MidiJack;
using System;

/// <summary>
/// MIDI Keyboard controller
///     Detecting midi keys pressed, released, holded
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class NoteIndicatorKeys : MonoBehaviour
{
    public NoteActivated noteActivate;
    public delegate void ActivateNote();
    public static event ActivateNote ChangeNoteStatus;
    
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
            SetProperColor();
            PlaySoundOnPress(KeyState.Up);
        }
        if (WasJustPressed())
        {
            SetProperColor();
            PlaySoundOnPress(KeyState.Down);
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

    public void PlaySoundOnPress(KeyState key)
    {
        if (key == KeyState.Down)
        {
           // ChangeNoteStatus += new ActualNote_ActivateNote();
            audioSource.Play(0);
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

    public int GetNoteNumber
    {
        get { return noteNumber; }
    }

    public float GetXNotePosition()
    {
        return this.gameObject.transform.position.x;
    }
    // to test
    public void GetNoteInfo(out int num, out float xPos)
    {
        num = this.noteNumber;
        xPos = this.gameObject.transform.position.x;
    }

    void ActualNote_ActivateNote()
    {
        noteActivate.Number = GetNoteNumber;
    }
}
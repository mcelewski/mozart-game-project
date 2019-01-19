using System;
using MidiJack;
using UnityEngine;

public class NoteController : MonoBehaviour, IDisposable
{
/// <summary>
/// MIDI Keyboard controller supporting PC keyboard controller
///     Detecting midi keys pressed, released, holded
/// </summary>
/// 
    public DesktopKeyboardController keyboard;
    public KeyState keyState = KeyState.Up;
    public IsMidi midiConnected = IsMidi.Desktop;
    public NotesInfo noteInfo;
    
    
    void Update()
    {
       UpdateKeyState();
    }
    
    void UpdateKeyState()
    {
        if (midiConnected == IsMidi.Midi)
        {
            if (WasJustReleased())
            {
                keyState = KeyState.Up;
                PlaySoundOnPress(keyState);
                SetProperColor();
            }
            if (WasPres())
            {
                keyState = KeyState.Down;
                PlaySoundOnPress(keyState);
                SetProperColor();
            }
        }
        else
        {
            keyboard.DetectKey();
        }
    }
    private bool WasJustReleased()
    {
        return MidiMaster.GetKeyUp(noteInfo.noteNumber); //  || MidiMaster.GetKey(noteNumber) < 0.01f
    }
    
    private bool WasPres()
    {
        return MidiMaster.GetKeyDown(noteInfo.noteNumber);
    }
    
    private bool WasJustPressed()
    {
        if (MidiMaster.GetKey(noteInfo.noteNumber) > 0.5f && keyState == KeyState.Up)
            return true;
        return MidiMaster.GetKeyDown(noteInfo.noteNumber);
    }

    public void PlaySoundOnPress(KeyState key)
    {
        if (key == KeyState.Down)
        {
            noteInfo.StartPlaying(0);
        }
    }

    public void SetProperColor()
    {
        Color color;
        if (!noteInfo.isWhite)
            color = (keyState == KeyState.Down) ? Color.red : Color.black;
        else
            color = (keyState == KeyState.Down) ? Color.red : Color.white;
        GetComponent<Renderer>().material.color = color;
    }

    public void SetKeyState(KeyState key)
    {
        keyState = key;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

public enum KeyState
{
    Up, Down
}

public enum IsMidi
{
    Midi, Desktop
}

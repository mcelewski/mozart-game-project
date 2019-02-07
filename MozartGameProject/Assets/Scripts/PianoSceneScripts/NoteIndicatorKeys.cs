using UnityEngine;
using MidiJack;

/// <summary>
/// MIDI Keyboard controller supporting PC keyboard controller
///     Detecting midi keys pressed, released, holded
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class NoteIndicatorKeys : MonoBehaviour
{
   // public NoteActivated noteActivate;
    public KeyboardController keyboard;
    
    public int noteNumber;
    public bool isWhite;
    public AudioSource audioSource;
    public KeyState keyState = KeyState.Up;

    public enum KeyState
    {
        Up, Down
    }

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
       // noteActivate = GameObject.FindGameObjectWithTag("Finish").GetComponent<NoteActivated>();
        keyboard = GameObject.FindGameObjectWithTag("Player").GetComponent<KeyboardController>();
        if (audioSource == null)
            GetComponent<AudioSource>();
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
            PlaySoundOnPress(keyState);
            SetProperColor();
        }
        if (WasPres())
        {
            keyState = KeyState.Down;
            PlaySoundOnPress(keyState);
            SetProperColor();
        }
        keyboard.DetectKey();
    }
    bool WasJustReleased()
    {
        return MidiMaster.GetKeyUp(noteNumber); //  || MidiMaster.GetKey(noteNumber) < 0.01f
    }
    
    bool WasPres()
    {
        return MidiMaster.GetKeyDown(noteNumber);
    }
    
    bool WasJustPressed()
    {
        if (MidiMaster.GetKey(noteNumber) > 0.5f && keyState == KeyState.Up)
            return true;
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

    public void SetProperColor()
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
        //noteActivate.Number = GetNoteNumber;
    }

    public bool IsWhiteKeyboard
    {
        get { return isWhite; }
    }

    public void SetKeyState(KeyState key)
    {
        keyState = key;
    }
}
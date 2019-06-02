using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;
using System;

///<summary>
/// Publisher key events
///</summary>
public class NoteKeyBehaviour : MonoBehaviour, INoteBehaviour
{
    public OnPressAction pressAction;
    public OnHoldAction holdAction;
    public OnReleaseAction releaseAction;
    ///<summary>
    /// Required object audio source
    ///</summary>
    public AudioSource audioSource;
    ///<summary>
    /// Determine default object keycode
    ///</summary>
    public KeyCode code;
    ///<summary>
    /// Determine default object colour
    ///</summary>
    public ObjectsColoursState defaultColor = ObjectsColoursState.Default;
    ///<summary>
    /// Color property used to determine color to change
    ///</summary>
    public Color32 _color;
    ///<summary>
    /// Actual keynote status
    ///</summary>
    public KeyNoteState state = KeyNoteState.Released;
    ///<summary>
    /// Holds current pushed time
    ///</summary>
    [SerializeField]private float _pushedTime = 0.0f;
    ///<summary>
    /// Allow to play with PC or Mini Keyboard
    ///</summary>
    [SerializeField]private bool _playAsMidi;
    ///<summary>
    /// Object _localId property to hold data
    ///</summary>
    [SerializeField] private ushort _localId;
    #region Properties
    ///<summary>
    /// Get or Set data to Play as Mini Keyboard or PC
    ///</summary>
    public bool PlayAsMidi { get { return _playAsMidi; } set { _playAsMidi = value; } }
    ///<summary>
    /// Allow to change minimum holded time
    ///</summary>
    public float HoldTime { get; protected set; } 
    #endregion
    #region Private Methods
    ///<summary>
    /// Set default color on start
    ///</summary>
    private void SetProperColor(Color32 color)
    {
        GetComponent<Renderer>().material.color = color;
    }
    ///<summary>
    /// Set proper color based on keystate
    ///</summary>
    private void SetProperColor(KeyNoteState keyState)
    {
        if(IsKeyPressed() && IsWhiteNoteDefault())
        {
            SetProperColor(new Color32(0,128,0,255));
        }
        else if (IsKeyPressed() && IsBlackNoteDefault())
        {
            SetProperColor(new Color32(255,255,0,255));
        }
        if(IsKeyReleased())
        {
            SetProperColor(_color);
        }
    }
    private void Play()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.Play(0);
    }
    private void Stop()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
    ///<summary>
    /// Play when midi is set up
    ///</summary>
    private void PlayMidi()
    {
        if(WasPres())
        {
            state = KeyNoteState.Pressed;
            Play();
        }
        if(WasJustReleased())
        {
            state = KeyNoteState.Released;
            Stop();
        }
    }
    ///<summary>
    /// Play when PC keyboard is selected
    ///</summary>
    private void PlayPC()
    {
        if(Input.GetKeyDown(code))
        {
            state = KeyNoteState.Pressed;
            Play();
        }
        if(Input.GetKeyUp(code))
        {
            state = KeyNoteState.Released;
            StopCounterHoldedKey();
            Stop();
        }
    }
    ///<summary>
    /// Start counting holded key time
    ///</summary>
    private void StartCounterHoldedKey()
    {
        if(IsKeyPressed() || WasPres())
        {
            _pushedTime+= 1f * Time.deltaTime;
        }
        else 
        {
            StopCounterHoldedKey();
        }
    }
    ///<summary>
    /// Detect if key is down more than 2 seconds
    ///</summary>
    private void DetectHoldedKey()
    {
        float time = 0.2f;
        // FIXME: time == lenght of smallest enemy 
        //   (smallest mean push key not hold)
        if(_pushedTime >= time)
        {
            state = KeyNoteState.Holded;
        }
    }
    ///<summary>
    /// Stop counter and reset pushed time
    ///</summary>
    private void StopCounterHoldedKey()
    {
        _pushedTime = 0.0f;
    }
    ///<summary>
    /// Fire proper action
    ///</summary>
    private void DetectAction()
    {
        if(IsKeyPressed())
        { 
            pressAction.SetKeyData(_localId);
            //OnKeyPress(_localId);
        }
        if(IsKeyReleased())
        {
            releaseAction.SetKeyData(_localId);
            // FIXME: Stop add points
            //releaseAction.EndPoiting();
            //OnKeyRelease(_localId);
        }
        if(IsKeyHolded())
        {
            holdAction.SetKeyData(_localId);
            //OnKeyHold(_localId);
        }
    }
    ///<summary>
    /// Detect if object is disabled and unregister events
    ///</summary>
    private void OnDestroy()
    {
        if(!this.isActiveAndEnabled)
        {
            Debug.Log("destroyed");
            UnregisterEvents();
        }
    }
    #endregion
    ///<summary>
    /// Builded in Unity methods
    ///</summary>
    #region Unity
    private void Update()
    {
        if (PlayAsMidi == false)
        {
            PlayPC();
        }
        if(PlayAsMidi == true)
        {
            PlayMidi();
        }

        DetectHoldedKey();
        DetectAction();
        StartCounterHoldedKey();
        SetProperColor(state);
        OnDestroy();
    }
    private void Start()
    {
        if(HaveNoneCode() && HasNullOrEmptyClip())
        {
            throw new MissingComponentException ("There is one or more missing component in " + this.name + " game object");
        }

        if(audioSource == null)
        {
           audioSource = GetComponent<AudioSource>();
        }
        if(!HadProperColor() && IsWhiteNoteDefault())
        {
            _color = new Color32(255,255,255,255);
        }
        if (!HadProperColor() && IsBlackNoteDefault())
        {
            _color = new Color32(0,0,0,255);
        }
        SetProperColor(_color);
        RegisterEvents();
        _localId = GetComponent<ItemInfo>().id;
        // TODO: add to settings as checkbox
        PlayAsMidi = false;
    }
    #endregion
    #region Event Methods
    ///<summary>
    /// Register a default object events
    ///</summary>
    private void RegisterEvents()
    {
        ItemActions.OnInputPress += OnKeyPress;
        ItemActions.OnInputRelease += OnKeyRelease;
        ItemActions.OnInputHold += OnKeyHold;
    }
    ///<summary>
    /// Unregister events
    ///</summary>
    public virtual void UnregisterEvents()
    {
        ItemActions.OnInputPress -= OnKeyPress;
        ItemActions.OnInputRelease -= OnKeyRelease;
        ItemActions.OnInputHold -= OnKeyHold;
    }
    private void OnKeyPress(ushort id)
    {
        ItemActions.OnPress(id);
    }
    private void OnKeyHold(ushort id)
    {
        ItemActions.OnHold(id);
    }
    private void OnKeyRelease(ushort id)
    {
        ItemActions.OnRelease(id);
    }
    #endregion
    #region Booleans
    private bool HaveNoneCode()
    {
        return code == KeyCode.None;
    }
    private bool HadProperColor()
    {
        return (_color.Equals(Color.black) || _color.Equals(Color.white));
    }
    private bool HasNullOrEmptyClip()
    {
        return audioSource == null && audioSource.clip == null;
    }
    private bool IsWhiteNoteDefault()
    {
        return defaultColor == ObjectsColoursState.White;
    }
    private bool IsBlackNoteDefault()
    {
        return defaultColor == ObjectsColoursState.Black;
    }
    private bool IsKeyPressed()
    {
        return state == KeyNoteState.Pressed;
    }
    private bool IsKeyReleased()
    {
        return state == KeyNoteState.Released;
    }
    private bool IsKeyHolded()
    {
        return state == KeyNoteState.Holded;
    }
    // #####################################################################################
    //                                  Midi master
    private bool WasJustReleased()
    {
        return MidiMaster.GetKeyUp(_localId); //  || MidiMaster.GetKey(noteNumber) < 0.01f
    }
    private bool WasPres()
    {
        return MidiMaster.GetKeyDown(_localId);
    }
    // #####################################################################################

    // TODO: check the midi if no need delete
    /* 
    private bool WasJustPressed()
    {
        if (MidiMaster.GetKey(id) > 0.5f && state == KeyNoteState.Released)
            return true;
        return MidiMaster.GetKeyDown(id);
    } */
    #endregion
}

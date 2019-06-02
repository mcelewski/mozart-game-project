using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PC keyboard:
///     Get elemnts from scene,
///     Assign to them keycode,
///     Play different sount depend on keycode
///     Set keystate
///     Set note color
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
                CurrentlyPressedNoteEvent.Note_OnPressed(singleNote.GetNoteNumber);
            }
            if (Input.GetKeyUp(key))
            {
                singleNote.SetKeyState(NoteIndicatorKeys.KeyState.Up);
                singleNote.SetProperColor();
                CurrentlyPressedNoteEvent.Note_OnReleased(singleNote.GetNoteNumber);
            }
        }
    }
}
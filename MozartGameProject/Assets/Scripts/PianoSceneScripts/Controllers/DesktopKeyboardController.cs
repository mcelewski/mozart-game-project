using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopKeyboardController : MonoBehaviour
{
    public Dictionary<KeyCode, NotesInfo> DesktopNotes = new Dictionary<KeyCode, NotesInfo>();

    public void DetectKey()
    {
        Debug.Log("");
    }
}

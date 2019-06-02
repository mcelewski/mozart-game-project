using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentlyPressedNoteEvent : MonoBehaviour
{
    ///<summary>
    /// Chain class only for event handler
    ///</summary>
    public static event Action<int> OnNotePressed;
    public static event Action<int> OnNoteHolded;
    public static event Action<int> OnNoteReleased;

    public static void Note_OnPressed(int id)
    {
        if(OnNotePressed != null)
        {
            OnNotePressed(id);
        }
    }
    public static void Note_OnHolded(int id)
    {
        if(OnNoteHolded != null)
        {
            OnNoteHolded(id);
        }
    }

    public static void Note_OnReleased(int id)
    {
        if(OnNoteReleased != null)
        {
            OnNoteReleased(id);
        }
    }
}

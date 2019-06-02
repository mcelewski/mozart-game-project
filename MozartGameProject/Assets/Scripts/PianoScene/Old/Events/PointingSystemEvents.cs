using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingSystemEvents : MonoBehaviour
{
    ///<summary>
    /// Holds 3 type of action events needed to calculate points
    ///</summary>
    private string text = "Compare: ";
    private int[] _idToCompare = new int[2];
    private int point = 0;
    void Start()
    {
        PlayerPrefs.DeleteAll();

        PointingSenderEvent.OnNoteEnter += NoteEntered_Info;
        PointingSenderEvent.OnNoteStay += NoteStayed_Info;

        CurrentlyPressedNoteEvent.OnNotePressed += EnteredNote_Compare;
        CurrentlyPressedNoteEvent.OnNoteHolded += EnteredNote_Compare;
        CurrentlyPressedNoteEvent.OnNoteReleased += EnteredNote_Compare;
    }

    private void NoteEntered_Info(int id)
    {
        _idToCompare[0] = id;
    }
    private void NoteStayed_Info(int id)
    {
        _idToCompare[1] = id;
    }

    private void EnteredNote_Compare(int id)
    {
        Debug.Log(text + "ID: " + _idToCompare[0] + "With: " + id);
        if (_idToCompare[0] == id)
        {
            point++;
            Debug.Log("Actual points: " + point);
        }
        if (_idToCompare[1] == id)
        {
            point+=2;
            Debug.Log("Actual points: " + point);
        }
        Debug.Log("After: " + text + "ID: " + _idToCompare[1] + "With: " + id);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    /// <summary>
    /// Set Note info where false == black note, true == white note
    /// Single note all info
    /// </summary>
    public delegate void OnNoteChanges();
    public static event OnNoteChanges ChangeNoteStatus;

    public int noteNumber;
    public float noteLenght;
    public bool isWhite = false;

    private Vector3 _whiteNoteScale = new Vector3(4f, 1f, .2f);
    private Vector3 _blackNoteScale = new Vector3(2f, 1f, .1f);

    public int NoteNumber
    {
        get { return noteNumber; }
        set { noteNumber = value; }
    }

    public float NoteLenght
    {
        get { return noteLenght; }
        set { noteLenght = value; }
    }

    public bool IsWhite
    {
        get { return isWhite; }
        set { isWhite = value; }
    }

    public void ChangeNoteScale(bool c)
    {
        if (c == true)
        {
            this.gameObject.transform.localScale += _whiteNoteScale;
        }
        else
        {
            this.gameObject.transform.localScale += _blackNoteScale;
        }
    }
    public void SetNoteLocation(float n)
    {
        this.gameObject.transform.position = new Vector3(n, transform.position.y, transform.position.z);
    }

    // Set all info
    public void SetNote(bool color, int number, float lenght, float position)
    {
        ChangeNoteScale(color);
        IsWhite = color;
        NoteNumber = number;
        NoteLenght = lenght;
        SetNoteLocation(position);
        ChangeNoteStatus += NoteBehaviour_ChangeNoteStatus;
    }

    private void NoteBehaviour_ChangeNoteStatus()
    {
        // send message was created
    }
}

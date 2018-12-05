using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    /// <summary>
    /// Set note info:
    ///     IsWhite false == black color note, 
    ///             true == white color note
    ///     Change note scale:
    ///             for white _whiteNoteScale,
    ///             for black _blackNoteScale
    ///     Set note lenght:
    ///             change transform local scale z
    ///     Set note number:
    ///             set note number to later determine global position
    ///     Set note position:
    ///             set position depend on in scene note position
    /// In method SetNote
    /// </summary>
   
    public delegate void OnNoteChanges();
    public static event OnNoteChanges ChangeNoteStatus;

    #region Default values
    private int noteNumber;
    private float noteLenght;
    private float startPosition;
    private bool isWhite;

    private Vector3 _whiteNoteScale = new Vector3(4f, 1f, .2f);
    private Vector3 _blackNoteScale = new Vector3(2f, 1f, .1f);
    #endregion

    #region Accessors

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

    #endregion

    #region Private Methods

    private void ChangeNoteScale(bool c)
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
    private void SetNoteLocation(float x, float p)
    {
        this.gameObject.transform.position = new Vector3(x, transform.position.y, p);
    }

    private void SetNoteLenght(float l)
    {
        this.gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, l);
    }

    private void SetNoteColor(bool color)
    {
        // if false = black else white
        if (!color)
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
        else
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    private void NoteBehaviour_ChangeNoteStatus()
    {
        // send message note was created
        Debug.Log("Note Created or disabled");
    }

    #endregion

    // Set all info
    public void SetNote(bool color, int number, float lenght, float position, float start)
    {
        SetNoteColor(color);
        ChangeNoteScale(color);
        SetNoteLenght(lenght);
        NoteNumber = number;
        SetNoteLocation(position, start);
        ChangeNoteStatus += NoteBehaviour_ChangeNoteStatus;
    }

    public bool DisableNote()
    {
        this.gameObject.SetActive(false);
        ChangeNoteStatus += NoteBehaviour_ChangeNoteStatus;
        return true;
    }
}

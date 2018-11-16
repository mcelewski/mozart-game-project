using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Experimental.UIElements;
using UnityEngine;

public class NoteInfo : MonoBehaviour
{
    /// <summary>
    /// Set Note info where false == black note, true == white note
    /// </summary>
    
    #region Variables
    private Dictionary<int, bool> noteDict = new Dictionary<int, bool>();
    private GameObject _note;
    private Vector3 _whiteNoteScale = new Vector3(4f, 1f, .2f);
    private Vector3 _blackNoteScale = new Vector3(2f, 1f, .1f);
    #endregion

    #region Private Methods
    void Start()
    {
        SetNoteDictionary();
    }

    void SetNoteDictionary()
    {
        for (int i = 48; i < 73; i++)
        {
            if (i == 49 || i == 51 || i == 54 || i == 56 ||
                i == 58 || i == 61 || i == 63 || i == 66 ||
                i == 68 || i == 70)
            {
                noteDict.Add(i, false);
            }
            else
            {
                noteDict.Add(i, true);
            }
        }
    }
    #endregion

    #region Public Methods
    public void ChangeNoteScale(float x, bool c)
    {
        if (c == true)
        {
            this._blackNoteScale.z = x;
        }
        else
        {
            this._whiteNoteScale.z = x;
        }
    }

    public void SetNoteLocation(float n)
    {
        _note.transform.position = new Vector3(n, transform.position.y, transform.position.z);
    }
    #endregion

    #region Accesors
    public Vector3 GetWhiteNoteScale
    {
        get { return _whiteNoteScale; }
    }
    public Vector3 GetBlackNoteScale
    {
        get { return _blackNoteScale; }
    }
    #endregion
}

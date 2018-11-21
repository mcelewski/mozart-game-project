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
    
    public Dictionary<int,bool> GetNotesInfo(int search, out int number, out bool color)
    {
        if (noteDict.ContainsKey(search))
        {
            /*
            number = noteDict.Keys;
            color = noteDict.Values;
            */
        }
    }
    
}

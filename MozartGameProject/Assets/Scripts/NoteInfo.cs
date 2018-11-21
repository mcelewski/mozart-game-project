using System.Collections;
using System.Collections.Generic;
using System.IO;
using MidiLoader.Events.SystemRealTime;
using UnityEditor.Experimental.UIElements;
using UnityEngine;

[ExecuteInEditMode]
public class NoteInfo : MonoBehaviour
{
    /// <summary>
    /// Default info about notes in scene
    ///     Number; Color; LocalPosition x;
    /// </summary>
    
    // use own struct
    public struct NotesInScene
    {
        public int number;
        public bool isWhite;
        public float xPosition;
    }
    
    #region Variables
    private Dictionary<int, bool> _noteDict = new Dictionary<int, bool>();
    public List<Transform> _notePositionList = new List<Transform>();
    public GameObject _main;

    public List<NotesInScene> _NotesInScenes = new List<NotesInScene>();

    private bool _notesReaded = false;
    #endregion

    public void Foo()
    {
        NotesInScene n = new NotesInScene();
        n.number = 2;
        n.isWhite = false;
        n.xPosition = 2.0f;

        _NotesInScenes.Add(n);
    }

    #region Private Methods
    void Start()
    {
        SetNoteDictionary();

        // Set note pos list
        if (_main != null && _notesReaded == false)
        {
            var childTransforms = _main.GetComponentsInChildren<Transform>();
            foreach (var trans in childTransforms)
            {
                // 0 elem is parent
                _notePositionList.Add(trans);
            }

            _notesReaded = true;
        }
    }

    private void SetNoteDictionary()
    {
        for (int i = 48, j = 1; i < 73; i++, j++)
        {
            if (i == 49 || i == 51 || i == 54 || i == 56 ||
                i == 58 || i == 61 || i == 63 || i == 66 ||
                i == 68 || i == 70)
            {
                _noteDict.Add(i, false);
            }
            else
            {
                _noteDict.Add(i, true);
            }
        }
    }
    #endregion
    
    // no in use need fix
    public void GetNotesInfo(int search, out int number, out bool color)
    {
        // avaiable
        number = 0;
        color = false;

        foreach (var item in _noteDict)
        {
            
            if (_noteDict.ContainsKey(search))
            {
                // not avaiable
                number = item.Key;
                color = item.Value;
            }
        }
    }
    
}
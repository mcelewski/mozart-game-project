﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteInfo : MonoBehaviour
{
    /// <summary>
    /// Default info about notes in scene
    ///     Number; Color; LocalPosition x;
    /// </summary>
    
    // own struct
    public struct NotesInScene
    {
        public int number;
        public bool isWhite;
        public float xPosition;
    }
    
    #region Variables
    private Dictionary<int, NotesInScene> _noteFull = new Dictionary<int, NotesInScene>();
    public List<Transform> _notePositionList = new List<Transform>();

    public GameObject _main;
    #endregion

    #region Private Methods
    void Start()
    {
        SetNoteDictionary();
        if (_notePositionList.Count < 25)
        {
            GetSceneNotesTransforms();
        }
        
        //CheckNotesList();
    }

    private void SetNoteDictionary()
    {
        NotesInScene singleNote = new NotesInScene();
        // j = 1 to skip parent from list
        for (int i = 48, j = 1; i < 73; i++, j++)
        {
            singleNote.number = i;
            singleNote.xPosition = _notePositionList[j].transform.localPosition.x;
            if (i == 49 || i == 51 || i == 54 || i == 56 ||
                i == 58 || i == 61 || i == 63 || i == 66 ||
                i == 68 || i == 70)
            {
                singleNote.isWhite = false;
            }
            else
            {
                singleNote.isWhite = true;
            }

            _noteFull.Add(i, singleNote);
        }
    }
    private void GetSceneNotesTransforms()
    {
        if (_main != null)
        {
            var childTransforms = _main.GetComponentsInChildren<Transform>();
            foreach (var trans in childTransforms)
            {
                // Element at 0 index is parent
                _notePositionList.Add(trans);
            }
        }
    }
    // Run in Start() if needed
    private void CheckNotesList()
    {
        foreach (var item in _noteFull)
        {
            Debug.Log("Number: " + item.Value.number + " IsWhite?: " + item.Value.isWhite + " PositionX: " + item.Value.xPosition);
        }
    }
    #endregion

    public Dictionary<int, NotesInScene> GetNoteFullList
    {
        get { return _noteFull; }
    }
}
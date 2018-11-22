using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[ExecuteInEditMode]
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
    //private Dictionary<int, bool> _noteDict = new Dictionary<int, bool>();
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
        CheckNotesList();
    }

    private void SetNoteDictionary()
    {
        NotesInScene singleNote = new NotesInScene();
        for (int i = 48, j = 1; i < 73; i++, j++)
        {
            singleNote.number = i;
            // pos from parent
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
                // At 0 index elem is parent
                _notePositionList.Add(trans);
            }
        }
    }
    private void CheckNotesList()
    {
        foreach (var item in _noteFull)
        {
            Debug.Log("Number: " + item.Value.number + " IsWhite?: " + item.Value.isWhite + " PositionX: " + item.Value.xPosition);
        }
    }
    #endregion
}
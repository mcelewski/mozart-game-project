using System.Collections.Generic;
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
    Dictionary<int, NotesInScene> _noteFull = new Dictionary<int, NotesInScene>();
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

    void SetNoteDictionary()
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
    void GetSceneNotesTransforms()
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
    void Print()
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

/*
 * Rozmiar tego etapu gry max 200 mb
 * 
 * 1. Plik midi:
 *     ładowanie do obiektu na scenie
 *     informacje z obiektu chce wykorzystać do ustawienia na scenie już obiektów tj.
 *     start(pozycja od 0), długość nuty, Id (numer nuty) względem wyciszenia :) ustawiam tylko nuty z głośnością 70%.
 * 
 *     muszę też przekonać unity żeby puszczało mi inny midi gdzie nie będzie wyciszonych dźwięków (dobra albo w werjsi wav puszczać)
 * 
 * 2. Pointing system
 *     zepsułem, mam detekcje na cube na trigger: enter, stay, exit ale nie wiem jak to zgrac z klawiszami przypisanymi z klawiatury.
 *     przy keyboardzie jest to łatwe do zrobienia bo keyboard daje dźwięk z cube o tym samym numerze,
 *     problem pojawia sie przy sterowaniu klawiaturą gdzie dźwięki są ustawione na sztywno (chyba że moge jakoś przypisać keycode do cube na scenie)
 * 
 */
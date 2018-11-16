using System.Collections;
using System.Collections.Generic;
using System.IO;
using MidiLoader;
using UnityEngine;

public class NoteInfo : MonoBehaviour
{
    public int noteNumber;
    public float noteLenght;
    public bool isWhite = false;
    //public GameObject noteBar;
    public Object midiFile;
    public MidiLoader.Loader load;

    public int NoteNumber
    {
        get { return noteNumber;} set { noteNumber = value; }
    }

    public float NoteLenght
    {
        get { return noteLenght; } set { noteLenght = value; }
    }

    public bool IsWhite
    {
        get { return isWhite; } set { isWhite = value; }
    }

    void SearchBaseKey()
    {
        //noteBar = GameObject.Find(NoteNumber.ToString()).GetComponent<GameObject>();
    }

    void Start()
    {
        GetMidiFilePath();
    }

    void GetMidiFilePath()
    {
        string path = Path.GetFullPath(midiFile.name);
        path += ".mid";
        //Debug.Log(path);
        load = new Loader(path);
    }
}

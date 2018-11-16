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
    public Object midiFile;
    public MidiLoader.Loader load;

    private Dictionary<int, bool> noteDict = new Dictionary<int, bool>();
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

    void Start()
    {
        GetMidiFilePath();
        SetNoteDictionary();

        foreach (var item in noteDict)
        {
            Debug.Log(item);
        }
    }

    void GetMidiFilePath()
    {
        string path = Path.GetFullPath(midiFile.name);
        //path += ".mid";
        //Debug.Log(path);
        //load = new Loader(path);
        FileStream file = new FileStream(midiFile.name , FileMode.Open);
    }

    void SetNoteDictionary()
    {
        for (int i = 48; i < 73; i++)
        {
            if (i == 49)
            {
               noteDict.Add(i,false);
            }
            else if(i == 51)
            {
                noteDict.Add(i, false);
            }
            else if (i == 54)
            {
                noteDict.Add(i, false);
            }
            else if (i == 56)
            {
                noteDict.Add(i, false);
            }
            else if (i == 58)
            {
                noteDict.Add(i, false);
            }
            else if (i == 61)
            {
                noteDict.Add(i, false);
            }
            else if (i == 63)
            {
                noteDict.Add(i, false);
            }
            else if (i == 66)
            {
                noteDict.Add(i, false);
            }
            else if (i == 68)
            {
                noteDict.Add(i, false);
            }
            else if (i == 70)
            {
                noteDict.Add(i, false);
            }
            noteDict.Add(i, false);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using MidiLoader;
using MidiLoader.Parser;
using UnityEngine;

public class ConvertMidiToStorage : MonoBehaviour
{
    public ProjectMidiFilesStorage midiFilesList;
    //public MidiLocalStorage midiInfoToStore;

    public MidiLoader.Loader loader;
    public MidiLoader.Parser.HeaderInfo header;
    public MidiLoader.Parser.TrackInfo tracks;

    private void Start()
    {
        ConvertFileToObject();
    }

    void ConvertFileToObject()
    {
        header = new HeaderInfo();
        string[] fName;
        int size = midiFilesList.GetMidiFiles.Capacity;
        int miditotal = header.tracksCount;
        Debug.Log("Total tracks: " + miditotal);
        fName = new string[size];
        size = 0;

        foreach (var item in midiFilesList.GetMidiFiles)
        {
            fName[size] = item.ToString();
            size++;
        }
        
        SetFile(fName[1]);
        GetFileInfo();
        //Debug.Log("File: " + fName[0]);
    }

    void SetFile(string path)
    {
        loader = new Loader(path);
    }

    void GetFileInfo()
    {
        for(int i = 0; i < loader.trackInfos.Length; i++)
        {
            Debug.Log("Item at: " + i + "is: " + tracks.ToString());
        }
    }
}

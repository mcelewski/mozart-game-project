using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MidiLoader;
using MidiLoader.Parser;
using UnityEngine;
using UnityEngine.UI;

public class ConvertMidiToStorage : MonoBehaviour
{
    public ProjectMidiFilesStorage midiFilesList;
    public Loader loader;

    private void Start()
    {
        ConvertFileToObject();
    }

    void ConvertFileToObject()
    {
        string[] fName;
        int size = midiFilesList.GetMidiFiles.Capacity;
        
        fName = new string[size];
        size = 0;

        foreach (var item in midiFilesList.GetMidiFiles)
        {
            fName[size] = item.ToString();
            size++;
        }
        
        SetFile(fName[1]);
        GetFileInfo();
    }

    void SetFile(string path)
    {
        loader = new Loader(path);
    }

    void GetFileInfo()
    {
        for(int i = 0; i < loader.trackInfos.Length; i++)
        {
            Debug.Log(loader.trackInfos[i].ToString());
        }
    }
}

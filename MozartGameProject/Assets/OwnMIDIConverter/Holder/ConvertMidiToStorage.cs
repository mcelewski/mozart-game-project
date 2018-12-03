using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MidiLoader;
using MidiLoader.Parser;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Think about this way 
/// </summary>
public class ConvertMidiToStorage : MonoBehaviour
{
    public ProjectMidiFilesStorage midiFilesList;

    private void Start()
    {
        ShowMeTheWay();
        SetMidiLocal();
    }

    void ShowMeTheWay()
    {
        OpenStream oStream = new OpenStream();
        oStream.SetMidiPath = GetFileToParse(2);
        
        if (false == oStream.OpenMidiFile())
        {
            Debug.Log("\nCouldn't open");
        }
    }

    string GetFileToParse(int index)
    {
        return midiFilesList.GetMidiFiles.ElementAt(index).ToString();
    }

    void SetMidiLocal()
    {
        var localMidi = new MidiLocalStorage(.2f,1.5f,2.8f,55,80,180,true);
        localMidi.ShowInfo();
    }
}

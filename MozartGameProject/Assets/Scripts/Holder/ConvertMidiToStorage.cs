using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    }

    void ShowMeTheWay()
    {
        OpenStream oStream = new OpenStream();
        oStream.SetMidiPath = GetFileToParse(0);
        
        if (false == oStream.OpenMidiFile())
        {
            Debug.Log("\nCouldn't open");
        }
    }

    string GetFileToParse(int index)
    {
        return midiFilesList.GetMidiFiles.ElementAt(index).ToString();
    }
}

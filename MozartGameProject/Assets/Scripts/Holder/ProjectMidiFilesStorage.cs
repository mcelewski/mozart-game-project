using System.IO;
using System.Collections.Generic;
using UnityEngine;

using Object = System.Object;

/// <summary>
/// Getting all files contained in midi files folder and hold them
/// Without update files option
/// </summary>

public class ProjectMidiFilesStorage : MonoBehaviour
{
    string _fdName = "Assets\\MidiFiles";
    List<Object> _midiFiles = new List<Object>();
    string[] _fNames;

    #region Unity Methods

    void Awake()
    {
        if (_midiFiles.Count < 1)
        {
            SetFiles();
        }
    }

    #endregion

    #region Private Methods

    void SetFiles()
    {
        _fNames = Directory.GetFiles(_fdName, "*.mid");
        int count = Directory.GetFiles(_fdName, "*.mid").Length;

        for (int i = 0; i < count; i++)
        {
            _midiFiles.Add(_fNames[i]);
        }

    }

    void CheckFiles()
    {
        Debug.Log("Checking files...");
        if (_midiFiles != null)
        {
            foreach (var file in _midiFiles)
            {
                Debug.Log("Midi file: " + file.ToString());
            }
        }
        else
            Debug.Log("Couldn't find any files in list");
    }

    #endregion

    #region Accessor
    // Only get list
    public List<Object> GetMidiFiles
    {
        get
        {
            return _midiFiles;
        }
    }
    #endregion
}
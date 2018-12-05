using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behaviour to detect and compare selected note and assigment key
/// </summary>

public class NoteActivated : MonoBehaviour 
{
    public NoteBehaviour noteSettings;
    
    private int _notePressedNumber;
    public int Number
    {
        get { return _notePressedNumber;}
        set { _notePressedNumber = value; }
    }

    /*
     * private void Update()
    {
        Debug.Log("Clicked key at number: " + Number);
    }
     */

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish") && noteSettings.NoteNumber == Number)
            Debug.Log("Enter death zone");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Finish") && noteSettings.NoteNumber == Number)
            Debug.Log("In death zone");
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Finish") && noteSettings.NoteNumber == Number)
            Debug.Log("Over death zone");
    }
}

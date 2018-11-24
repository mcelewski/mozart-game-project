using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behaviour to detect and compare selected note and assigment key
/// </summary>

public class NoteActivated : MonoBehaviour 
{
    public delegate void ActivateNote();
    public static event ActivateNote ChangeNoteStatus;

    public NoteBehaviour noteSettings;
    public NoteIndicatorKeys noteKeys;
    public KeyboardController pcNoteKey;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish") && noteSettings.NoteNumber == noteKeys.GetNoteNumber)
            Debug.Log("Enter death zone");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Finish"))
            Debug.Log("In death zone");
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Finish"))
            Debug.Log("Over death zone");
    }
}

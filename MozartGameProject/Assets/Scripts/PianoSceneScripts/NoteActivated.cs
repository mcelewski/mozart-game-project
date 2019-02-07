using UnityEngine;

/// <summary>
/// Behaviour to detect and compare selected note and assigment key
/// </summary>

public class NoteActivated : MonoBehaviour 
{
    public NoteBehaviour noteSettings;
    
    int _notePressedNumber;
    public int Number
    {
        get { return _notePressedNumber;}
        set { _notePressedNumber = value; }
    }
    
    public void Print()
    {
        Debug.Log("Clicked key at number: " + Number);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish") && noteSettings.NoteNumber == Number)
            Debug.Log("Enter death zone");
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Finish") && noteSettings.NoteNumber == Number)
            Debug.Log("In death zone");
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Finish") && noteSettings.NoteNumber == Number)
            Debug.Log("Over death zone");
    }
}

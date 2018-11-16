using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBehaviour : MonoBehaviour
{
    public int noteNumber;
    public float noteLenght;
    public bool isWhite = false;

    public int NoteNumber
    {
        get { return noteNumber; }
        set { noteNumber = value; }
    }

    public float NoteLenght
    {
        get { return noteLenght; }
        set { noteLenght = value; }
    }

    public bool IsWhite
    {
        get { return isWhite; }
        set { isWhite = value; }
    }

}

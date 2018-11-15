using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInfo : MonoBehaviour
{
    public int noteNumber;
    public float noteLenght;
    public bool isWhite = false;
    public GameObject noteBar;

    public int NoteNumber { get; set; }
    public float NoteLenght { get; set; }
    public bool IsWhite { get; set; }

    void SearchBaseKey()
    {
        noteBar = GameObject.Find(NoteNumber.ToString()).GetComponent<GameObject>();
    }

    void SetPos()
    {
        //gameObject.transform.position.x = noteBar.transform.position.x;
    }
}

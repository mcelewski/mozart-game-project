using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Notes database", menuName = "Database/Notes in Scene")]

public class NotesDatabase : ScriptableObject
{
    public List<NotesInfo> NoteItemsDatabase = new List<NotesInfo>();
    
    public List<NotesInfo> GetDatabase()
    {
        return NoteItemsDatabase;
    }
}
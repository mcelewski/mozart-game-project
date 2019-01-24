using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopKeyboardController : MonoBehaviour
{
    public NotesDatabase notesDB;

    public void DetectKey()
    {
        if (notesDB.NoteItemsDatabase == null)
            Debug.Log("No items in database");
        else
        {
            foreach (var item in notesDB.NoteItemsDatabase)
            {
                if (Input.GetKeyDown(item.keyCode))
                {
                    item.StartPlaying(0);
                }
            }
        }
    }
}

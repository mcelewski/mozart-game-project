using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mechanic:
///
///     - Add to map only notes witch velocity is less or equal 70
///     - Set object info as notes
///     - Set map lenght as lenght of midi file
///
/// </summary>
public class SetMidiToScene : MonoBehaviour
{
    /*
     * Requierements:
     *      Note position in scene,
     *      Note prefab,
     *      Midi storage,
     */

    public NoteInfo noteInScene;
    public NoteBehaviour notePrefab;
    public MidiLocalStorage midiLocalStorage;
    
    /*
     * Get info and set in scene
     */

    private void MakeAction(MidiLocalStorage midiLocal)
    {
        bool setToUse = false;
        int number = 0;
        float lenght = 0f;
        float noteBeign = 0f;
        float noteOver = 0f;
        // while i < total in midi note count
        for (int i = 0; i < 200; i++)
        {
            number = CheckNoteVelocity(70, out setToUse, 23);
            lenght = CalculateLenght(noteBeign, noteOver);
            if (setToUse)
            {
                SetPrefabToScene(number, lenght, noteBeign);
            }
        }        
    }
    
    private int CheckNoteVelocity(int velocity, out bool set, int number)
    {
        set = 70 <= velocity ? set = true : set = false;
        return number;
    }

    private float CalculateLenght(float start, float end)
    {
        return end - start;
    }

    private void SetPrefabToScene(int noteNumber, float noteLenght, float noteStartPos)
    {
        /*
         * Get note to play number
         * Set the location of note
         * Set the lenght of note
         * Set size of note
         */
        foreach (var item in noteInScene.GetNoteFullList)
        {
            if (noteNumber == item.Key)
            {
                var gameObject = new GameObject{name = "note", tag = "Enemy"}; // name + tag
                var noteBehaviour = gameObject.AddComponent<NoteBehaviour>();
                
                var noteCollider = gameObject.AddComponent<BoxCollider>();
                noteCollider.isTrigger = true;
                
                noteBehaviour.SetNote(item.Value.isWhite,item.Value.number,noteLenght,item.Value.xPosition,noteStartPos);
            }
        }
     }
}

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
    public List<GameObject> prefabToInsert = new List<GameObject>();
    
    /*
     * Get info and set in scene
     */

    void MakeAction(MidiLocalStorage midiLocal)
    {
        bool setToUse = false;
        int number = 0;
        float lenght;
        foreach (var item in midiLocal.GetMidiTempStruct)
        {
            number = CheckNoteVelocity(item.noteVelocity, out setToUse, item.noteNumber);
            lenght = CalculateLenght(item.noteOnTick, item.noteOffTick);
            if (setToUse)
            {
                SetPrefabToScene(number, lenght);
            }
        }
    }

    int CheckNoteVelocity(int velocity, out bool set, int number)
    {
        set = 70 <= velocity ? set = true : set = false;
        return number;
    }

    float CalculateLenght(float start, float end)
    {
        return end - start;
    }

    void SetPrefabToScene(int noteNumber, float noteLenght)
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
                var gameObject = new GameObject{name = "go"}; // name + tag
                var noteBehaviour = gameObject.AddComponent<NoteBehaviour>();
                // add to game object
                noteBehaviour.SetNote(item.Value.isWhite,item.Value.number,noteLenght,item.Value.xPosition);
                prefabToInsert.Add(gameObject);
            }
        }
     }
}

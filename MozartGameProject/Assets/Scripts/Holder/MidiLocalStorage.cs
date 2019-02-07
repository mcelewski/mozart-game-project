using UnityEngine;

/// <summary>
/// Hold midi file information
///
/// Require info:
///
///     Midi file lenght - total file size
///     All notes count - total amount of notes in file
/// 
///     Note on tick - in event
///     Note off tick - in event
///     Note number - in note id
///     Note velocity - in note volume
///     Note duration - note length calculated from on and off tick event
///
/// </summary>

public class MidiLocalStorage
{
    struct MidiNoteTempStruct
    {
        public static float noteOnTick;
        public static float noteOffTick;
        public static int noteNumber;
        public static int noteVelocity;
        public static bool readyToSet;
    }
    
    struct MidiFileOverallInfo
    {
        public static float midiFileLength;
        public static int totalNotesAmount;
    }

    public MidiLocalStorage(float midiLength, float noteOnTick, float noteOffTick, int noteNumber, int noteVelocity, int noteCount, bool readyToSet)
    {
        MidiNoteTempStruct.noteOnTick = noteOnTick;
        MidiNoteTempStruct.noteOffTick = noteOffTick;
        MidiNoteTempStruct.noteNumber = noteNumber;
        MidiNoteTempStruct.noteVelocity = noteVelocity;
        MidiNoteTempStruct.readyToSet = readyToSet;

        MidiFileOverallInfo.midiFileLength = midiLength;
        MidiFileOverallInfo.totalNotesAmount = noteCount;
    }

    public void ShowInfo()
    {
        Debug.Log("\nMidi info: \n\tLength: " + MidiFileOverallInfo.midiFileLength + 
                  "\n\tNote Count: " + MidiFileOverallInfo.totalNotesAmount + 
                  "\n\tNote on tick: " + MidiNoteTempStruct.noteOnTick + 
                  "\n\tNote off tick: " + MidiNoteTempStruct.noteOffTick + 
                  "\n\tNote number: " + MidiNoteTempStruct.noteNumber + 
                  "\n\tNote velocity: " + MidiNoteTempStruct.noteVelocity + 
                  "\n\tIs ready to set: " + MidiNoteTempStruct.readyToSet);
    }
}

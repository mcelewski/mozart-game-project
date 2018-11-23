using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hold midi file information
///
/// Require info:
///
///     Midi file lenght
///     Note on tick
///     Note off tick
///     Note number
///     Note velocity
///     Note duration
///     All notes count
///
/// </summary>

public class MidiLocalStorage : MonoBehaviour
{
    public List<MidiTempStruct> MidiStorage = new List<MidiTempStruct>();

    public struct MidiTempStruct
    {
        public float midiFileTotalLenght; // midi duration
        public float noteOnTick;
        public float noteOffTick;
        public int noteNumber;
        public int noteVelocity;
        public int noteCount;
        public bool readyToSet;
    }

    public MidiLocalStorage(float midiLenght, float noteOnTick, float noteOffTick, int noteNumber, int noteVelocity, int noteCount, bool readyToSet)
    {
        MidiTempStruct midiTemp = new MidiTempStruct();

        midiTemp.midiFileTotalLenght = midiLenght;
        midiTemp.noteOnTick = noteOnTick;
        midiTemp.noteOffTick = noteOffTick;
        midiTemp.noteNumber = noteNumber;
        midiTemp.noteVelocity = noteVelocity;
        midiTemp.noteCount = noteCount;
        midiTemp.readyToSet = readyToSet;

        MidiStorage.Add(midiTemp);
    }

    public List<MidiTempStruct> GetMidiTempStruct { get { return MidiStorage; } }
}

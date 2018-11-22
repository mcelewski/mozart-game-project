using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hold midi file information
/// Information type:
/// 
///     Header;
///     Track info;
///     Track lenght;
///     Over midi lenght;
///     Channel ID;
///     Note number;
///     
/// Require info:
/// 
///     Midi file lenght
///     Note on tick
///     Note off tick
///     Note number
///     Note velocity
///     Note duration
/// Mechanic:
/// 
///     - Add to map only notes witch velocity is less or equal 70
///     - Set object info as notes
///     - Set map lenght as lenght of midi file
/// </summary>

public class MidiLocalStorage : MonoBehaviour
{
    public struct MidiTempStruct
    {
        public float midiFileTotalLenght;
        public float noteOnTick;
        public float noteOffTick;
        public int noteNumber;
        public int noteVelocity;
    }

    public enum MidiSelect
    {
        Special = 1,
        Random = 2
    }
    private void SelectMidi(int ch)
    {
        if (ch == (int)MidiSelect.Special)
            SelectSpecialMidi();
        else if (ch == (int)MidiSelect.Random)
            SelectRandomMidi();
        else
            Debug.Log("Nothing happen.");
    }

    private void SelectSpecialMidi()
    {
        // Choose special track
    }

    private void SelectRandomMidi()
    {
        // Random select from base
    }
}

using System;
using UnityEngine;

/// <summary>
///     Determine file format
///     Determine file lenght
/// </summary>

public class GrandFileFormat
{
    // Default file format
    private string format;
    private int chunkSize;

    public enum MidiFormat
    {
        Single_MultiChannelTrack, // Single track
        OneOrMore_simultaneousTrack, // Multiply track, synchronous
        OneOrMore_independentTrack // Multiply track, asynchronous
    }

    public MidiFormat SetupMidiFormat;

    public void DetectFormat(byte[] file)
    {
        uint data = 0; // max val = 2 x 4 bytes = 32 bits = 8 589 934 591 max value
        string format = "";
        
        if (0 == (file[0] >> 7))
            SetupMidiFormat = MidiFormat.Single_MultiChannelTrack; // midi file
        else
            Debug.Log("Non midi format."); // non midi file

        // Determine data length
        data = ((uint)file[4] << 24) + ((uint)file[5] << 16) + ((uint)file[6] << 8) + ((uint)file[7] << 0);
        
        GetASCIICode(file,ref format);
        
        Debug.Log("format: " + format + "\tlength: " + data);
    }
    
    // Chunk type in ASCII
    void GetASCIICode(byte[] f, ref string onformat)
    {
        char[] type = new char[4];

        for (int j = 0; j < 4; j++)
        {
            type[j] = (char) f[j];
        }

        onformat = new string(type);
    }
    
    // Set midi format
    void GetMidiFormat(byte[] f, ref MidiFormat format)
    {
        // mask for 0, 1, 2
        
    }
}
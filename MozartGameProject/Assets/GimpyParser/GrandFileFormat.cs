using System;
using UnityEditor;
using UnityEngine;

/// <summary>
///     Determine file format
///     Determine file lenght
/// </summary>

public class GrandFileFormat
{
    private enum MidiFormat
    {
        Single_MultiChannelTrack, // Single track
        OneOrMore_simultaneousTrack, // Multiply track, synchronous
        OneOrMore_independentTrack // Multiply track, asynchronous -> usually not in use save drums etc..
    }

    private MidiFormat SetupMidiFormat;

    public void DetectFormat(byte[] file)
    {
        string format = "";
        uint chunkSize = 0; // max val = 2 x 4 bytes = 32 bits = 8 589 934 591 max value
        uint trackAmount = 0;
        uint timeDivision = 0;
        
        // Check if it's midi format
        if (0 != (file[0] >> 7))
            Debug.Log("Non midi format."); // non midi file
        
        
    //--------------------------------------------------------------------//
        GetASCIICode(ref file,ref format);
        GetSizeOfChunk(ref file,ref chunkSize);
        GetMidiFormatType(ref file, ref SetupMidiFormat);
        GetNumberOfTracks(ref file, ref trackAmount);
        if (!GetTimeDivision(ref file, ref timeDivision))
            Debug.Log("No needed format");
    //--------------------------------------------------------------------//
        
        Debug.Log("File format: " + format +
                  "\tChunk size: " + chunkSize + 
                  "\tTrack info: " + SetupMidiFormat +
                  "\tTime division: " + timeDivision);
    }
    
    // Chunk type in ASCII
    private static void GetASCIICode(ref byte[] file, ref string onformat)
    {
        char[] type = new char[4];

        for (int j = 0; j < 4; j++)
        {
            type[j] = (char) file[j];
        }
        
        onformat = new string(type);
    }
    
    // Determine data length
    private static void GetSizeOfChunk(ref byte[] file, ref uint data)
    {
        data = ((uint)file[4] << 24) + ((uint)file[5] << 16) + ((uint)file[6] << 8) + ((uint)file[7] << 0);
    }

    // Set midi format
    private static void GetMidiFormatType(ref byte[] file, ref MidiFormat format)
    {
        uint data = ((uint) file[8] << 8) + ((uint) file[9] << 0);
        
        if (0 == data)
        {
            format = MidiFormat.Single_MultiChannelTrack;
        }
        else if (1 == data)
        {
            format = MidiFormat.OneOrMore_simultaneousTrack;
        }
        else if (2 == data)
        {
            format = MidiFormat.OneOrMore_independentTrack;
        }
    }
    
    // Get amount of tracks
    private static void GetNumberOfTracks(ref byte[] file, ref uint amount)
    {
        const uint amountMask = 0xFF;
        amount = (file[10] & amountMask) + (file[11] & amountMask);
    }
    
    // Get time division
    private static bool GetTimeDivision(ref byte[] file, ref uint division)
    {
        /*
         * If the top bit of the word (bit mask 0x8000) is 0,
         * the following 15 bits describe the time division in ticks per beat.
         *
         * Ticks per beat translate to the number of clock ticks or track delta positions
         * (described in the Track Chunk section) in every quarter note of music.
         * 
         * Common values range from 48 to 960, although newer sequencers go far beyond this range to
         * ease working with MIDI and digital audio together.
         */
        
        const uint determineTicksMask = 0x8000;
        const uint valueMask = 0x7FFF;

        if (0 == (file[12] & determineTicksMask))
        {
            division = ((uint)(file[12] << 1 )& valueMask) + (file[13] & valueMask);
            if (!(48 <= division) && !(960 >= division))
                return false;

            return true;
        }
        return false;
    }
    
    //Get track chunk
    private static void GetTrackChunk(ref byte[] file, ref )
    {
        /*
         * Beacouse the chunk ID is always "MTrk" (0x4D54726B) skip 
         */
        
    }
}
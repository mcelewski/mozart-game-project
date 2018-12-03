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
        
        // Check if it's midi format
        if (0 != (file[0] >> 7))
            Debug.Log("Non midi format."); // non midi file
        
        
    //--------------------------------------------------------------------//
        GetASCIICode(ref file,ref format);
        GetSizeOfChunk(ref file,ref chunkSize);
        GetMidiFormatType(ref file, ref SetupMidiFormat);
        GetNumberOfTracks(ref file, ref trackAmount);
    //--------------------------------------------------------------------//
        
        Debug.Log("File format: " + format +
                  "\tChunk size: " + chunkSize + 
                  "\tTrack info: " + SetupMidiFormat);
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
    private static void GetTimeDivision(ref byte[] file)
    {
        /*
         * If the top bit of the word (bit mask 0x8000) is 0,
         * the following 15 bits describe the time division in ticks per beat.
         * Otherwise the following 15 bits (bit mask 0x7FFF)
         * describe the time division in frames per second.
         */
        
        /*
         * Ticks per beat translate to the number of clock ticks or track delta positions
         * (described in the Track Chunk section) in every quarter note of music.
         * 
         * Common values range from 48 to 960, although newer sequencers go far beyond this range to
         * ease working with MIDI and digital audio together.
         * 
         * Frames per second is defined by breaking the remaining 15 bytes into two values.
         *
         * The top 7 bits (bit mask 0x7F00) define a value for the number of SMPTE frames and can be 24,
         * 25, 29 (for 29.97 fps) or 30.
         * 
         * The remaining byte (bit mask 0x00FF) defines how many clock ticks or track
         * delta positions there are per frame.
         *
         * So a time division example of 0x9978 could be broken down into
         * it's three parts: the top bit is one, so it is in SMPTE frames per second format,
         * the following 7 bits have a value of 25 (0x19)and the bottom byte has a value of 120 (0x78).
         * This means the example plays at 24 frames per second SMPTE time
         * and has 120 ticks per frame. 
         */
    }
}
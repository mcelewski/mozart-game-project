using System;
using UnityEngine;
/// <summary>
///     Determine file format
///     Determine file lenght
/// </summary>

public class GrandFileFormat : MonoBehaviour
{
    // Default file format
    private string format;
        
    
    public enum MidiFormat
    {
        Single_MultiChannelTrack,       // Single track
        OneOrMore_simultaneousTrack,    // Multiply track, synchronous
        OneOrMore_independentTrack      // Multiply track, asynchronous
    }

    public MidiFormat SetupMidiFormat;

    public void DetectFormat(byte[] file)
    {
        // Masks to determine file format
        int data = 0;     // max val = 2 x 4 bytes = 32 bits = 8 589 934 591 max value
       
        // Search begin of file for data 
        for (int i = 0; i < file.Length + 1; i++ )
        {
            if (0 == file[0])
                SetupMidiFormat = MidiFormat.Single_MultiChannelTrack;   // midi file
            else
                Debug.Log("Non midi format.");                           // non midi file
            
            // Chunk type in ASCII
            if (4 <= i)
            {
                char[] type = new char[4];
                
                type[0] = (char) file[0];
                type[1] = (char) file[1];
                type[2] = (char) file[2];
                type[3] = (char) file[3];

                this.format = new string(type);
            }
            
            // Chunk length determine data length
            if (4 <= i && 8 <= i)
            {
                data = BitConverter.ToInt32(file, 4);
            }
        }
    }
}
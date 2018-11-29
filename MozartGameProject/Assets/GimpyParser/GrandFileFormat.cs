using System;
using UnityEngine;
/// <summary>
///     Determine file format
///     Determine file lenght
/// </summary>

public class GrandFileFormat : MonoBehaviour
{
    // Default file format
    public MidiFormat fileFormat = MidiFormat.First_Format;
        
    public enum MidiFormat
    {
        First_Format,     // Single track
        Second_Format,    // Multiply track, synchronous
        Third_Format      // Multiply track, asynchronous
    }
    
    public void DetectFormat(byte[] file)
    {
        // Masks to determine file format
        byte type;     // 4 bytes
        byte length;   // 4 bytes determine data length
        byte data;     // max val = 2 x 4 bytes = 32 bits = 8 589 934 591 max value
            
        // Search begin of file for data 
        for (int i = 0; i < file.Length + 1; i++ )
        {
            byte[] tmp = file[i];
            if (i >= 8)
            {
                if (0 == tmp[0])
                    
            }
        }

        return true;
    }

    
}
using System;
using UnityEngine;

    public class GrandFileFormat : MonoBehaviour
    {
        // Default file format
        public MidiFormat fileFormat = MidiFormat.First_Format;
        
        public enum MidiFormat
        {
            First_Format, // Single track
            Second_Format, // Multiply track, synchronous
            Third_Format // Multiply track, asynchronous
        }

        MidiFormat DetectFormat(byte[] file)
        {
            // Masks to determine file format
            byte type; //4 bytes
            byte length;
            byte data; // max val 255
            
            // Search begin of file for data 
            for (int i = 0; i < file.Length + 1; i++)
            {
                if (0 == file[0])
                {
                    
                }
            }

            return MidiFormat.Second_Format;
        }
    }
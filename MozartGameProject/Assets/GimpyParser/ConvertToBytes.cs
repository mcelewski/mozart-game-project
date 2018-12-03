using System;
using System.IO;
using UnityEngine;

/// <summary>
///     Converting file to byte array
///         - Send array to forward analyse
/// 
/// </summary>

public class ConvertToBytes 
{
    public static int CopyToByteArray(byte[] bFile, out bool copied)
    {
        var grandformat = new GrandFileFormat();
        grandformat.DetectFormat(bFile);
        
        copied = false;
        return bFile.Length;
    }
}
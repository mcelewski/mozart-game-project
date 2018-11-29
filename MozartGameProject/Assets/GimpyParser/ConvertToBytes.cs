using System.IO;
using UnityEngine;

/// <summary>
///     Converting file to byte array
///         - Send array to forward analyse
/// 
/// </summary>

public class ConvertToBytes : MonoBehaviour 
{
    private static byte[] fileInfo;
    public int CopyToByteArray(FileStream fileStream, out bool copied)
    {
        fileInfo = new byte[fileStream.Length +1];
        while (fileStream.Read(fileInfo, 0, (int) fileStream.Length) > -1)
            ;

        if (fileInfo.Length >= fileStream.Length)
            copied = true;
        
        
        
        copied = false;
        return fileInfo.Length;
    }
}
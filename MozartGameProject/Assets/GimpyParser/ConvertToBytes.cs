using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConvertToBytes : MonoBehaviour 
{
    private static byte[] fileInfo;
    public void CopyToByteArray(FileStream fileStream, out bool copied)
    {
        fileInfo = new byte[fileStream.Length +1];
        while (fileStream.Read(fileInfo, 0, (int) fileStream.Length) > -1)
            ;

        if (fileInfo.Length >= fileStream.Length)
            copied = true;

        copied = false;
    }
}

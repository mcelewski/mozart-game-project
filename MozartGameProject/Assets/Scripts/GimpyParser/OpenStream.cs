using System.IO;
using UnityEngine;

/// <summary>
/// Simplify open midi file stream and send it to analyse
///     - Show info about bytes read in int format
/// 
/// </summary>

public class OpenStream
{
    string fPath = "";
    int bReaded = 0;
    bool openAndCopied = false;
    
    public string SetMidiPath
    {
        set { fPath = value; }
    }

    FileStream fStream;

    public bool OpenMidiFile()
    {
        
        /*
         * Open stream
         * Set pointer position to 0
         * Send stream Forward
         */

        if (File.Exists(fPath))
        {
            fStream = File.OpenRead(fPath); 
        }
        else
        {
            Debug.Log("File at: " + fPath + " doesn't exist.");
            openAndCopied = false;
            return openAndCopied;
        }
        
        if (fStream != null)
        {
            byte[] tmp;
            fStream.Position = 0;
            tmp = File.ReadAllBytes(fPath);
            bReaded = ConvertToBytes.CopyToByteArray(tmp, out openAndCopied);
        }
        
        Debug.Log("Bytes readed: " + bReaded);    // Show number of bytes readed in int format
        fStream.Close();    // Always remember to close stream
        openAndCopied = true;
        return openAndCopied;
    }
}
using System.IO;
using System.Net;
using UnityEngine;

/// <summary>
/// Simplify open midi file stream and send it to analyse
/// </summary>
public class OpenStream : MonoBehaviour
{
    private string fPath = "";
    bool openAndCopied = false;
    
    public string SetMidiPath
    {
        set { fPath = value; }
    }

    private FileStream fStream;

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
            openAndCopied = false;
            return openAndCopied;
        }
        
        if (fStream != null)
        {
            fStream.Position = 0;
            ConvertToBytes step = new ConvertToBytes();
            step.CopyToByteArray(fStream, out openAndCopied);
        }

        return openAndCopied;
    }
}

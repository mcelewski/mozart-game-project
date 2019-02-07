/// <summary>
///     Converting file to byte array
///         - Send array to forward analyse
/// 
/// </summary>

public class ConvertToBytes 
{
    public static int CopyToByteArray(byte[] bFile, out bool copied)
    {
        var grandFormat = new GrandFileFormat();
        grandFormat.DetectFormat(bFile);
        
        copied = false;
        return bFile.Length;
    }
}
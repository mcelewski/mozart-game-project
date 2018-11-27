using System.Collections;
using System.Collections.Generic;
using System.IO;

public class FileReader
{
    public FileReader(string pathname)
    {
        FileStream fStream = new FileStream(pathname,FileMode.Open, FileAccess.Read);
        
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _03_CookieCookbook.FileAccess;

    public enum FileFormat
    {
        txt, json
    }

public class DataRepository
{
   
    public void Read(string filePath)
    {
        var content = File.ReadAllText(filePath);
    }
}

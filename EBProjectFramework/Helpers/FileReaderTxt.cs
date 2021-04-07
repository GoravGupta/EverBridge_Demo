using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EBProjectFramework.Helpers
{
    public class FileReaderTxt
    {
        readonly string filePath = "";
        public FileReaderTxt(string filePath)
        {
            this.filePath = filePath;
        }

        public string[] ReadFile()
        {
            string[] lines = null;
            if (File.Exists(filePath))
            {
                // Read a text file line by line.  
                lines = File.ReadAllLines(filePath);
            }
            else
            {
                LogHelper.Write("No Input File Found at " + filePath);
            }
            return lines;
        }
    }
}

using EBProjectFramework.config;
using System;
using System.IO;

namespace EBProjectFramework.Helpers
{
    public class LogHelper : IEnvData
    {
        //Global Declaration
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;
        static string dir = IEnvData.LOG_FOLDER_PATH;
        static string filePath = dir + _logFileName + ".log";
        //Create a file which can store the log information
        private static void CreateLogFile()
        {
            if (!File.Exists(filePath))
            {
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
        }
            //Create a method which can write the text in the log file
        public static void Write(string logMessage)
        {
            CreateLogFile();
            _streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamw.WriteLine("    {0}", logMessage);
            _streamw.Flush();
        }


    }
}

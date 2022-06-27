using System;
using System.IO;

namespace Cache_Cleaner
{
    internal class Logger
    {
        private static string currentDir = Environment.CurrentDirectory;
        private static string path = currentDir + @"\Cache Cleaner Logs\" + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + ".txt";
        private static FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
        private StreamWriter logFile = new StreamWriter(fs);

        public void startLog()
        {
            logFile.Write("\r\nLog Entry : ");
            logFile.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            logFile.WriteLine("Deleting Files;\n");
        }

        public void writeLog(string message)
        {
            logFile.WriteLine("\t" + message);
        }

        public void closeLog(int errors)
        {
            logFile.WriteLine("\nERRORS IN LOG: " + errors);
            logFile.WriteLine("\nEND OF LOG");
            logFile.Flush();
        }
    }
}

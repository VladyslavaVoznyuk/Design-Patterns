using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class FileWriter
    {
        private string _logFile;

        public FileWriter(string logFile)
        {
            _logFile = logFile;
        }

        public void Write(string text)
        {
            using (StreamWriter sw = new(_logFile, true))
            {
                sw.Write(text);
            }
        }

        public void WriteLine(string text)
        {
            using (StreamWriter sw = new(_logFile, true))
            {
                sw.WriteLine(text);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class FileLogger : ILogger
    {
       
        private FileWriter _fileWriter;

        public FileLogger(FileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public void Log(string message)
        {
            _fileWriter.WriteLine(message);
        }

        public void Error(string errorMessage)
        {
            _fileWriter.WriteLine($"Error: {errorMessage}");
        }

        public void Warn(string warnMessage)
        {
            _fileWriter.WriteLine($"Warn: {warnMessage}");
        }
    }
}

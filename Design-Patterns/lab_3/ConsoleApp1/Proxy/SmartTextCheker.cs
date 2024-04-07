using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class SmartTextCheker : ISmartTextReader
    {
        private ISmartTextReader _reader;

        public SmartTextCheker(SmartTextReader reader)
        {
            _reader = reader;
        }

        public void OpenFile(string path)
        {
            _reader.OpenFile(path);
            Console.WriteLine("File opened.");
        }

        public void CloseFile()
        {
            _reader.CloseFile();
            Console.WriteLine("File closed.");
        }

        public string[] GetFileContent()
        {
            var content = _reader.GetFileContent();

            Console.WriteLine("File content readed:");
            Console.WriteLine($"Total count of rows: {content.Length}");

            int characters = 0;
            foreach (var line in content)
            {
                characters += line.Length;
            }

            Console.WriteLine($"Total count of characters: {characters}");

            return content;
        }

    }
}

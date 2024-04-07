using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class SmartTextReader : ISmartTextReader
    {
        private StreamReader? _streamReader;

        public SmartTextReader()
        {
        }

        public SmartTextReader(string path)
        {
            OpenFile(path);
        }

        public void OpenFile(string path)
        {
            if (_streamReader != null)
            {
                throw new InvalidOperationException("You can't open another file, while you already open one. Use Close method then OpenFile again.");
            }

            _streamReader = new StreamReader(path);
        }

        public void CloseFile()
        {
            if (_streamReader == null)
            {
                throw new InvalidOperationException("File already closed.");
            }
            _streamReader.Close();
            _streamReader = null;
        }


        public string[] GetFileContent()
        {
            if (_streamReader == null)
            {
                throw new InvalidOperationException("Please open file before getting the content.");
            }

            List<string> content = new();

            while (!_streamReader.EndOfStream)
            {
               
                content.Add(_streamReader.ReadLine() ?? "");
            }

            return content.ToArray();
        }
    }
}

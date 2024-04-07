using System.Text.RegularExpressions;

namespace Proxy
{
    public class TextLocker : ISmartTextReader
    {
        private ISmartTextReader _reader;

        private Regex _securedFilesRegex;

        public TextLocker(ISmartTextReader reader, Regex securedFilesRegex)
        {
            _reader = reader;
            _securedFilesRegex = securedFilesRegex;
        }

        public void CloseFile()
        {
            _reader.CloseFile();
        }

        public string[] GetFileContent()
        {
            return _reader.GetFileContent();
        }

        public void OpenFile(string path)
        {
            if (_securedFilesRegex.IsMatch(path))
            {
                Console.WriteLine("Access denied!");
                return;
            }

            _reader.OpenFile(path);
        }
    }
}

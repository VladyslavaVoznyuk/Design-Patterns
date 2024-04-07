using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface ISmartTextReader
    {
        public void OpenFile(string path);

        public void CloseFile();

        public string[] GetFileContent();
    }
}

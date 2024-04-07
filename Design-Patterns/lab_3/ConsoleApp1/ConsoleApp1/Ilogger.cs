using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public interface ILogger
    {
        public void Log(string message);

        public void Error(string errorMessage);

        public void Warn(string warnMessage);
    }
}

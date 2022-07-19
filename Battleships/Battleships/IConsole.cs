using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public interface IConsole
    {
        void WriteLine(string message);
        void WriteLine(string message, params object[] args);

        void Clear();

        string ReadLine();
    }
}

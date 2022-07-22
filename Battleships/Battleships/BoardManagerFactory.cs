using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    internal class BoardManagerFactory
    {
        public static BoardManager Create(int height, int width)
        {
            return new BoardManager(height, width);
        }
    }
}

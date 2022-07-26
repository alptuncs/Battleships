using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class BoardManagerFactory
    {
        public BoardManager Create(int height, int width)
        {
            return new BoardManager(height, width);
        }
    }
}

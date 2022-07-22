using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Coordinate
    {
        public int xPos { get; private set; }
        public int yPos { get; private set; }
        public Coordinate(int x, int y)
        {
            xPos = x;
            yPos = y;
        }
    }
}

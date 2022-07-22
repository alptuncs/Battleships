using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Coordinate
    {
        private int x;
        private int y;
        public int XPos { get { return x; } }
        public int YPos { get { return y; } }
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

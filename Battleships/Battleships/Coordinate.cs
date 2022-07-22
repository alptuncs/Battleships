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
        public int XPos => x;
        public int YPos => y;
        public Coordinate(int i, int j)
        {
            x = i;
            y = j;
        }
    }
}

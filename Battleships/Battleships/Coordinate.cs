using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Coordinate
    {
        private int _Xpos;
        private int _Ypos;
        public int XPos => _Xpos;
        public int YPos => _Ypos;
        public Coordinate(int i, int j)
        {
            _Xpos = i;
            _Ypos = j;
        }
    }
}

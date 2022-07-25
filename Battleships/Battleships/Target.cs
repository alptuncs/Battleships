using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Target
    {
        public int Size { get; private set; }
        public Direction Direction { get; private set; }
        public Target(int size, string direction, string name)
        {
            Size = size;
            Direction = new Direction(direction);
        }
    }
}

using System;

namespace Battleships
{
    public class Target
    {
        public int Size { get; private set; }
        public Direction Direction { get; private set; }

        public Target(int size, Direction direction)
        {
            Size = size;
            Direction = direction;
        }
    }
}

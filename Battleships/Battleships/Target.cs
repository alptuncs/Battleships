using System;

namespace Battleships
{
    public class Submarine : ITarget
    {
        public int Size { get { return 1; } }
        public Direction Direction { get; private set; }

        public void SetShipDirection(Direction direction)
        {
            Direction = direction;
        }
    }
    public class Minelayer : ITarget
    {
        public int Size { get { return 2; } }
        public Direction Direction { get; private set; }

        public void SetShipDirection(Direction direction)
        {
            Direction = direction;
        }
    }
    public class Destroyer : ITarget
    {
        public int Size { get { return 3; } }
        public Direction Direction { get; private set; }

        public void SetShipDirection(Direction direction)
        {
            Direction = direction;
        }
    }
    public class Flagship : ITarget
    {
        public int Size { get { return 4; } }
        public Direction Direction { get; private set; }

        public void SetShipDirection(Direction direction)
        {
            Direction = direction;
        }
    }
}

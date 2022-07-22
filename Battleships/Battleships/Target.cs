using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Target
    {
        private int size;
        private Direction direction;
        private Coordinate origin;

        private string name { get; set; }
        public int Size => size;
        public Direction Direction => direction;
        public Coordinate Origin => origin;
        public Target(int size, Direction direction, string name)
        {
            this.size = size;
            this.direction = direction;
            this.name = name;
        }

        public void SetOrigin(Coordinate coords)
        {
            origin = coords;
        }
    }
}

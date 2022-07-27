using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Direction
    {
        public string Value { get; private set; }

        public Direction(string direction)
        {
            Value = direction;
        }

        public static Direction East()
        {
            return new Direction("East");
        }
        public static Direction West()
        {
            return new Direction("West");
        }
        public static Direction North()
        {
            return new Direction("North");
        }
        public static Direction South()
        {
            return new Direction("South");
        }
    }
}

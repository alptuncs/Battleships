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
    }
}

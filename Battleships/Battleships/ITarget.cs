using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public interface ITarget
    {
        int Size { get; }
        Direction Direction{ get; }

        void SetShipDirection(Direction direction);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Cell
    {
        public bool hasShip { get; set; }
        public bool isHit { get; set; }
        public int shipType { get; set; }

        public Cell(bool hasShip, int shipType)
        {
            this.hasShip = hasShip;
            this.shipType = shipType;
            isHit = false;
        }
    }
}

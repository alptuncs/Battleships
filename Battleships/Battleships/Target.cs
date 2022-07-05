using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Target
    {
        private int xPos;
        private int yPos;

        public Target(int xPos, int yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public int GetXPos()
        {
            return xPos;
        }

        public int GetYPos()
        { 
            return yPos;
        }

    }
}

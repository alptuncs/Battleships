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
        private int size;
        private string direction;



        public int XPos => xPos;
        public int YPos => yPos;
        public int Size => size;

        public string Direction => direction;




        public Target(int size, string direction)
        {
            this.size = size;
            this.direction = direction;
        }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public struct cell
    {
        public bool hasShip;

        public cell(bool hasShip)
        {
            this.hasShip = hasShip;
        }
    }
    public class BoardManager
    {
        private cell[][] board;

        public BoardManager()
        {
            board = new cell[10][];

            for (int i = 0; i < 10; i++)
            {
                board[i] = Enumerable.Repeat(new cell(false), 10).ToArray();
            }
        }

        public void PlaceShip(int i, int j)
        {
            if (HasShip(i, j) == false)
            {
                board[i][j].hasShip = true;
            }
            else
            {
                Console.WriteLine("This cell is occupied");
            }
        }

        public bool HasShip(int i, int j)
        {
            return board[i][j].hasShip;
        }

        public void CheckNeighbors(Target target)
        {

        }

        public void RandomPlaceShip(int count)
        {
            if (count > 100)
            {
                throw new InvalidOperationException("Count can not exceed total cell count, total cell count = 100!");
            }

            Random random = new Random(10);

            int shipCounter = 0;

            while (shipCounter < count)
            {

                if (TryPlaceShip(random.Next(0, 10), random.Next(0, 10)))
                {
                    shipCounter++;
                }


            }

        }
        public bool TryPlaceShip(int x, int y)
        {
            if (HasShip(x, y))
            {
                return false;
            }

            board[x][y].hasShip = true;
            return true;
        }

    }
}

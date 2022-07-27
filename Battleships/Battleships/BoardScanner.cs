using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    internal class BoardScanner
    {
        public BoardScanner() { }

        public static List<Coordinate> GetShipCoordinates(BoardManager boardManager)
        {
            List<Coordinate> coordinateList = new List<Coordinate>();

            for (int i = 0; i < boardManager.Height; i++)
            {
                for (int j = 0; j < boardManager.Width; j++)
                {

                    if (boardManager.HasShip(new Coordinate(i, j)))
                    {
                        coordinateList.Add(new Coordinate(i, j));
                    }
                }
            }
            return coordinateList;
        }

    }
}

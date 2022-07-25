using System.Collections.Generic;

namespace Battleships
{
    public enum Direction
    {
        North,
        East,
        South,
        West,
        NorthEast,
        NorthWest,
        SouthEast,
        SouthWest
    }
    public class Coordinate
    {
        public int xPos { get; private set; }
        public int yPos { get; private set; }
        public Coordinate(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

        public static Coordinate GetNeighbour(Coordinate coordinate, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    if (coordinate._Xpos - 1 >= 0)
                    {
                        return new Coordinate(coordinate._Xpos - 1, coordinate.YPos);
                    }
                    return coordinate;
                case Direction.East:
                    if (coordinate._Ypos - 1 >= 0)
                    {
                        return new Coordinate(coordinate._Xpos, coordinate._Ypos + 1);
                    }
                    return coordinate;
                case Direction.South:
                    if (coordinate._Xpos + 1 < 10)
                    {
                        return new Coordinate(coordinate._Xpos + 1, coordinate._Ypos);
                    }
                    return coordinate;
                case Direction.West:
                    if (coordinate._Ypos - 1 >= 0)
                    {
                        return new Coordinate(coordinate._Xpos, coordinate._Ypos - 1);
                    }
                    return coordinate;
                default:
                    return coordinate;
            }
        }

        public List<Coordinate> GetAllNeighours(int xUpperBound, int yUpperBound, int xLowerBound = 0, int yLowerBound = 0)
        {
            List<Coordinate> neightbourList = new List<Coordinate>();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (_Xpos + i < xUpperBound && _Xpos + i >= xLowerBound && _Ypos + j >= yLowerBound && _Ypos + j < yUpperBound)
                    {
                        neightbourList.Add(new Coordinate(_Xpos + i, _Ypos + j));
                    }
                }
            }

            return neightbourList;
        }
    }
}

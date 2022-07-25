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
        public int XPos { get; private set; }
        public int YPos { get; private set; }
        public Coordinate(int x, int y)
        {
            XPos = x;
            YPos = y;
        }

        public static Coordinate GetNeighbour(Coordinate coordinate, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    if (coordinate.XPos - 1 >= 0)
                    {
                        return new Coordinate(coordinate.XPos - 1, coordinate.YPos);
                    }
                    return coordinate;
                case Direction.East:
                    if (coordinate.YPos - 1 >= 0)
                    {
                        return new Coordinate(coordinate.XPos, coordinate.YPos + 1);
                    }
                    return coordinate;
                case Direction.South:
                    if (coordinate.XPos + 1 < 10)
                    {
                        return new Coordinate(coordinate.XPos + 1, coordinate.YPos);
                    }
                    return coordinate;
                case Direction.West:
                    if (coordinate.YPos - 1 >= 0)
                    {
                        return new Coordinate(coordinate.XPos, coordinate.YPos - 1);
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
                    if (XPos + i < xUpperBound && XPos + i >= xLowerBound && YPos + j >= yLowerBound && YPos + j < yUpperBound)
                    {
                        neightbourList.Add(new Coordinate(XPos + i, YPos + j));
                    }
                }
            }

            return neightbourList;
        }
    }
}

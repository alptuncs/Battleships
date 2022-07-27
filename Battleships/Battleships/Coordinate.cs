using System.Collections.Generic;

namespace Battleships
{
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
            switch (direction.Value)
            {
                case "North":
                    if (coordinate.XPos - 1 >= 0)
                    {
                        return new Coordinate(coordinate.XPos - 1, coordinate.YPos);
                    }
                    return null;
                case "East":
                    if (coordinate.YPos + 1 < 10)
                    {
                        return new Coordinate(coordinate.XPos, coordinate.YPos + 1);
                    }
                    return null;
                case "South":
                    if (coordinate.XPos + 1 < 10)
                    {
                        return new Coordinate(coordinate.XPos + 1, coordinate.YPos);
                    }
                    return null;
                case "West":
                    if (coordinate.YPos - 1 >= 0)
                    {
                        return new Coordinate(coordinate.XPos, coordinate.YPos - 1);
                    }
                    return null;
                default:
                    return null;
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
        public static bool operator ==(Coordinate left, Coordinate right)
        {
            if (ReferenceEquals(left, right)) return true;

            if (left is null) return false;

            if (right is null) return false;

            return left.Equals(right);
        }
        public static bool operator !=(Coordinate left, Coordinate right) => !(left == right);

        public bool Equals(Coordinate other)
        {
            if (other is null) return false;

            if (ReferenceEquals(this, other)) return true;

            return XPos.Equals(other.XPos) && YPos.Equals(other.YPos);
        }

        public override bool Equals(object obj) => Equals(obj as Coordinate);
    }
}


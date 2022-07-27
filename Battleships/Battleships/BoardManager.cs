using System;
using System.Linq;

namespace Battleships
{
    public class BoardManager
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public int PlacedShips { get; private set; }
        public Cell[,] Board { get; private set; }

        public BoardManager(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            PlacedShips = 0;
            Board = new Cell[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Board[i, j] = new Cell(false, 0);
                }
            }
        }

        public bool HasShip(Coordinate coordinates)
        {
            return Board[coordinates.XPos, coordinates.YPos].hasShip;
        }

        public bool IsHit(Coordinate coordinates)
        {
            return Board[coordinates.XPos, coordinates.YPos].isHit;
        }

        public void HitSquare(Coordinate coordinates)
        {
            if (!IsHit(coordinates)) Board[coordinates.XPos, coordinates.YPos].isHit = true;
        }

        public void PlaceShip(Coordinate coordinate, ITarget ship)
        {
            if (!TryPlaceShip(coordinate, ship)) throw new Exception("Couldn't place ship");
        }

        public void PlaceShip(int count, ITarget ship)
        {
            if (count > 100) throw new InvalidOperationException("Count can not exceed total cell count, total cell count = 100!");

            Random random = new Random(10);
            int shipCounter = 0;

            while (shipCounter < count)
            {
                if (TryPlaceShip(new Coordinate(random.Next(0, Height), random.Next(0, Width)), ship)) shipCounter++;
            }
        }

        private bool TryPlaceShip(Coordinate coordinate, ITarget ship)
        {
            if (!CanPlaceShip(coordinate, ship)) return false;

            for (int i = 0; i < ship.Size; i++)
            {
                Board[coordinate.XPos, coordinate.YPos].hasShip = true;
                Board[coordinate.XPos, coordinate.YPos].shipType = ship.Size;
                coordinate = Coordinate.GetNeighbour(coordinate, ship.Direction);
            }
            PlacedShips++;
            return true;
        }

        public bool CanPlaceShip(Coordinate coordinate, ITarget ship)
        {
            if (HasShip(coordinate)) return false;

            if (!CheckAdjacentSquares(coordinate)) return false;

            for (int i = 0; i < ship.Size - 1; i++)
            {
                if (Coordinate.GetNeighbour(coordinate, ship.Direction) == null) return false;

                if (HasShip(Coordinate.GetNeighbour(coordinate, ship.Direction))) return false;

                if (!CheckAdjacentSquares(Coordinate.GetNeighbour(coordinate, ship.Direction))) return false;

                coordinate = Coordinate.GetNeighbour(coordinate, ship.Direction);
            }
            return true;
        }

        private bool CheckNeighbors(Coordinate coordinate, ITarget ship)
        {
            for (int i = 0; i < ship.Size; i++)
            {
                if (HasShip(coordinate) || !CheckAdjacentSquares(coordinate)) return false;

                if (Coordinate.GetNeighbour(coordinate, ship.Direction) == null) return false;

                coordinate = Coordinate.GetNeighbour(coordinate, ship.Direction);
            }
            return true;
        }

        public bool CheckAdjacentSquares(Coordinate coordinates)
        {

            foreach (Coordinate neighbour in coordinates.GetAllNeighours(Height, Width))
            {
                if (HasShip(neighbour)) return false;
            }
            return true;
        }
    }
}

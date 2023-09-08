using System;
using System.Collections.Generic;

namespace Battleships
{
    public class BoardManager
    {
        private Cell[,] cells;

        public int PlacedShips { get; private set; }
        public List<Coordinate> ShipCoordinates { get; private set; } = new();

        public int Height => cells.GetLength(0);
        public int Width => cells.GetLength(1);
        public Cell this[Coordinate coordinate] => this[coordinate.XPos, coordinate.YPos];
        public Cell this[int x, int y] => cells[x, y];

        public BoardManager(int height, int width)
        {
            cells = new Cell[height, width];
        }

        internal BoardManager Initialize()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    cells[i, j] = new();
                }
            }

            return this;
        }

        public void PlaceShip(Coordinate coordinate, ITarget ship)
        {
            if (!TryPlaceShip(coordinate, ship)) throw new Exception("Couldn't place ship");
        }

        public void PlaceShip(int count, ITarget ship)
        {
            if (count > Width * Height) throw new InvalidOperationException("Count can not exceed total cell count, total cell count = 100!");

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
                this[coordinate].PlaceShip(ship);
                ShipCoordinates.Add(coordinate);
                coordinate = coordinate.GetNeighbour(ship.Direction);
            }

            PlacedShips++;
            return true;
        }

        public bool CanPlaceShip(Coordinate coordinate, ITarget ship)
        {
            for (int i = 0; i < ship.Size - 1; i++)
            {
                if (this[coordinate].HasShip) return false;
                if (!CheckAdjacentSquares(coordinate)) return false;
                
                coordinate = coordinate.GetNeighbour(ship.Direction);

                if (coordinate == null) return false;
            }

            return true;
        }

        internal void RemoveShip(Coordinate coordinate)
        {
            ShipCoordinates.Remove(coordinate);
        }

        public bool CheckAdjacentSquares(Coordinate coordinates)
        {
            foreach (var neighbour in coordinates.GetAllNeighours(Height, Width))
            {
                if (this[neighbour].HasShip) return false;
            }

            return true;
        }
    }
}

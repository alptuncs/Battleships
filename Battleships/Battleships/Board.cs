using System;
using System.Collections.Generic;

namespace Battleships;

public class Board
{
    private readonly Cell[,] cells;

    public int PlacedShips { get; private set; }
    public List<Coordinate> ShipCoordinates { get; private set; } = new();

    public int Height => cells.GetLength(0);
    public int Width => cells.GetLength(1);
    public Cell this[Coordinate coordinate] => this[coordinate.XPos, coordinate.YPos];
    public Cell this[int x, int y] => cells[x, y];

    public Board(int height, int width)
    {
        cells = new Cell[height, width];
    }

    internal Board Initialize()
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

    public void PlaceShip(Coordinate coordinate, Target ship)
    {
        if (!TryPlaceShip(coordinate, ship)) throw new Exception("Couldn't place ship");
    }

    public void PlaceShip(int count, Target ship)
    {
        if (count > Width * Height) throw new InvalidOperationException("Count can not exceed total cell count, total cell count = 100!");

        Random random = new();
        int shipCounter = 0;

        while (shipCounter < count)
        {
            if (TryPlaceShip(new Coordinate(random.Next(0, Height), random.Next(0, Width)), ship)) shipCounter++;
        }
    }

    private bool TryPlaceShip(Coordinate coordinate, Target ship)
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

    public bool CanPlaceShip(Coordinate coordinate, Target ship)
    {
        for (int i = 0; i < ship.Size - 1; i++)
        {
            if (this[coordinate].HasShip) return false;
            if (!CheckAdjacentSquares(coordinate)) return false;

            coordinate = coordinate.GetNeighbour(ship.Direction);

            if (coordinate.XPos == -1) return false;
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

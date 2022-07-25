﻿using System;
using System.Linq;

namespace Battleships
{
    public struct Cell
    {
        public bool hasShip;
        public bool isHit;
        public int shipType;

        public Cell(bool hasShip, int shipType)
        {
            this.hasShip = hasShip;
            this.shipType = shipType;
            isHit = false;
        }
    }
    public class BoardManager
    {
        private int _height;
        private int _width;
        private int _placedShips;
        private Cell[][] board;
        public Cell[][] Board => board;
        public int PlacedShips => _placedShips;
        public BoardManager(int height, int width)
        {
            this._height = height;
            this._width = width;
            _placedShips = 0;
            board = new Cell[10][];

            for (int i = 0; i < height; i++)
            {
                board[i] = Enumerable.Repeat(new Cell(false, 0), width).ToArray();
            }
        }

        public bool HasShip(Coordinate coordinates)
        {
            if (CheckPlacementBounds(coordinates))
            {
                return board[coordinates.XPos][coordinates.YPos].hasShip;
            }

            throw new InvalidOperationException("Out of bounds");
        }
        public bool IsHit(Coordinate coordinates)
        {
            if (CheckPlacementBounds(coordinates))
            {
                return board[coordinates.XPos][coordinates.YPos].isHit;
            }
            throw new InvalidOperationException("Out of bounds");
        }
        public void HitSquare(Coordinate coordinates)
        {
            if (CheckPlacementBounds(coordinates) && !IsHit(coordinates))
            {
                board[coordinates.XPos][coordinates.YPos].isHit = true;
            }
        }

        public void PlaceShip(Coordinate coordinate, Target ship)
        {
            TryPlaceShip(coordinate, ship);
        }

        public void PlaceShip(int count, Target ship)
        {
            if (count > 100) throw new InvalidOperationException("Count can not exceed total cell count, total cell count = 100!");

            Random random = new Random(10);

            int shipCounter = 0;

            while (shipCounter < count)
            {
                if (TryPlaceShip(new Coordinate(random.Next(0, _height), random.Next(0, _width)), ship))
                {
                    shipCounter++;
                }
            }
        }

        private bool TryPlaceShip(Coordinate coordinate, Target ship)
        {
            if (!CanPlaceShip(coordinate, ship))
            {
                return false;
            }
            if (!CheckNeighbors(coordinate, ship))
            {
                return false;
            }
            switch (ship.Direction)
            {
                case Direction.North:
                    for (int i = 0; i < ship.Size; i++)
                    {
                        board[coordinate.XPos - i][coordinate.YPos].hasShip = true;
                        board[coordinate.XPos - i][coordinate.YPos].shipType = ship.Size;

                    }
                    _placedShips++;
                    return true;
                case Direction.South:
                    for (int i = 0; i < ship.Size; i++)
                    {
                        board[coordinate.XPos + i][coordinate.YPos].hasShip = true;
                        board[coordinate.XPos + i][coordinate.YPos].shipType = ship.Size;
                    }
                    _placedShips++;
                    return true;
                case Direction.East:
                    for (int i = 0; i < ship.Size; i++)
                    {
                        board[coordinate.XPos][coordinate.YPos + i].hasShip = true;
                        board[coordinate.XPos][coordinate.YPos + i].shipType = ship.Size;
                    }
                    _placedShips++;
                    return true;
                case Direction.West:
                    for (int i = 0; i < ship.Size; i++)
                    {
                        board[coordinate.XPos][coordinate.YPos - i].hasShip = true;
                        board[coordinate.XPos][coordinate.YPos - i].shipType = ship.Size;
                    }
                    _placedShips++;
                    return true;
                default:
                    return false;
            }
        }

        public bool CanPlaceShip(Coordinate coordinates, Target ship)
        {
            if (ship.Direction == Direction.North && coordinates.XPos - ship.Size < 0)
            {
                return false;
            }
            else if (ship.Direction == Direction.South && coordinates.XPos + ship.Size >= _height)
            {
                return false;
            }
            else if (ship.Direction == Direction.East && coordinates.YPos + ship.Size >= _height)
            {
                return false;
            }
            else if (ship.Direction == Direction.West && coordinates.YPos - ship.Size < 0)
            {
                return false;
            }
            return true;
        }

        private bool CheckPlacementBounds(Coordinate coordinates)
        {
            if (coordinates.XPos < 0)
            {
                return false;
            }
            else if (coordinates.XPos >= _height)
            {
                return false;
            }
            else if (coordinates.YPos >= _height)
            {
                return false;
            }
            else if (coordinates.YPos < 0)
            {
                return false;
            }
            return true;
        }

        private bool CheckNeighbors(Coordinate coordinate, Target ship)
        {
            for (int i = 0; i < ship.Size; i++)
            {
                if (coordinate == Coordinate.GetNeighbour(coordinate, ship.Direction))
                {
                    return false;
                }

                if (HasShip(coordinate) || !CheckAdjacentSquares(coordinate))
                {
                    return false;
                }

                coordinate = Coordinate.GetNeighbour(coordinate, ship.Direction);
            }
            return true;
        }

        public bool CheckAdjacentSquares(Coordinate coordinates)
        {

            foreach (Coordinate neighbour in coordinates.GetAllNeighours(_height, _width))
            {
                if (HasShip(neighbour))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

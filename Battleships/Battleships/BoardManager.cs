using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void PlaceShip(Coordinate coordinates, Target ship)
        {
            TryPlaceShip(coordinates, ship);
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
        public void RandomPlaceShip(int count, Target ship)
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
        public bool TryPlaceShip(Coordinate coordinates, Target ship)
        {
            if (ship.Size == 1)
            {
                if (CheckPlacementBounds(coordinates, ship))
                {
                    if (HasShip(coordinates) || !CheckAdjacentSquares(coordinates)) return false;
                    board[coordinates.XPos][coordinates.YPos].hasShip = true;
                    board[coordinates.XPos][coordinates.YPos].shipType = ship.Size;
                    _placedShips++;
                    return true;
                }
            }
            else
            {
                if (CheckPlacementBounds(coordinates, ship))
                {
                    if (CheckNeighbors(coordinates, ship))
                    {
                        switch (ship.Direction)
                        {
                            case "north":
                                for (int i = 0; i < ship.Size; i++)
                                {
                                    board[coordinates.XPos - i][coordinates.YPos].hasShip = true;
                                    board[coordinates.XPos - i][coordinates.YPos].shipType = ship.Size;

                                }
                                _placedShips++;
                                return true;
                            case "south":
                                for (int i = 0; i < ship.Size; i++)
                                {
                                    board[coordinates.XPos + i][coordinates.YPos].hasShip = true;
                                    board[coordinates.XPos + i][coordinates.YPos].shipType = ship.Size;
                                }
                                _placedShips++;
                                return true;
                            case "east":
                                for (int i = 0; i < ship.Size; i++)
                                {
                                    board[coordinates.XPos][coordinates.YPos + i].hasShip = true;
                                    board[coordinates.XPos][coordinates.YPos + i].shipType = ship.Size;
                                }
                                _placedShips++;
                                return true;
                            case "west":
                                for (int i = 0; i < ship.Size; i++)
                                {
                                    board[coordinates.XPos][coordinates.YPos - i].hasShip = true;
                                    board[coordinates.XPos][coordinates.YPos - i].shipType = ship.Size;
                                }
                                _placedShips++;
                                return true;
                            default:
                                return false;
                        }
                    }
                    return false;
                }
            }
            return false;
        }
        public bool CheckPlacementBounds(Coordinate coordinates, Target ship)
        {
            if (ship.Direction == "north" && coordinates.XPos - ship.Size < 0)
            {
                return false;
            }
            else if (ship.Direction == "south" && coordinates.XPos + ship.Size >= _height)
            {
                return false;
            }
            else if (ship.Direction == "east" && coordinates.YPos + ship.Size >= _height)
            {
                return false;
            }
            else if (ship.Direction == "west" && coordinates.YPos - ship.Size < 0)
            {
                return false;
            }
            return true;
        }
        public bool CheckPlacementBounds(Coordinate coordinates)
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
        public bool CheckNeighbors(Coordinate coordinates, Target ship)
        {
            for (int i = 0; i < ship.Size; i++)
            {
                if (ship.Direction == "north")
                {
                    if (HasShip(new Coordinate(coordinates.XPos - i, coordinates.YPos)) || !CheckAdjacentSquares(new Coordinate(coordinates.XPos - i, coordinates.YPos)))
                    {
                        return false;
                    }
                }
                else if (ship.Direction == "south")
                {
                    if (HasShip(new Coordinate(coordinates.XPos + i, coordinates.YPos)) || !CheckAdjacentSquares(new Coordinate(coordinates.XPos + i, coordinates.YPos)))
                    {
                        return false;
                    }
                }
                else if (ship.Direction == "east")
                {
                    if (HasShip(new Coordinate(coordinates.XPos, coordinates.YPos + i)) || !CheckAdjacentSquares(new Coordinate(coordinates.XPos, coordinates.YPos + i)))
                    {
                        return false;
                    }
                }
                else if (ship.Direction == "west")
                {
                    if (HasShip(new Coordinate(coordinates.XPos, coordinates.YPos - i)) || !CheckAdjacentSquares(new Coordinate(coordinates.XPos, coordinates.YPos - i)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool CheckAdjacentSquares(Coordinate coordinates)
        {
            if (coordinates.XPos + 1 < _height)
            {
                if (HasShip(new Coordinate(coordinates.XPos + 1, coordinates.YPos)))
                {
                    return false;
                }
            }
            if (coordinates.XPos - 1 >= 0)
            {
                if (HasShip(new Coordinate(coordinates.XPos - 1, coordinates.YPos)))
                {
                    return false;
                }
            }
            if (coordinates.YPos + 1 < _width)
            {
                if (HasShip(new Coordinate(coordinates.XPos, coordinates.YPos + 1)))
                {
                    return false;
                }
            }
            if (coordinates.YPos - 1 >= 0)
            {
                if (HasShip(new Coordinate(coordinates.XPos, coordinates.YPos - 1)))
                {
                    return false;
                }
            }
            if (coordinates.YPos + 1 < _width && coordinates.XPos + 1 < _height)
            {
                if (HasShip(new Coordinate(coordinates.XPos + 1, coordinates.YPos + 1)))
                {
                    return false;
                }
            }
            if (coordinates.YPos + 1 < _width && coordinates.XPos - 1 >= 0)
            {
                if (HasShip(new Coordinate(coordinates.XPos - 1, coordinates.YPos + 1)))
                {
                    return false;
                }
            }
            if (coordinates.YPos - 1 >= 0 && coordinates.XPos + 1 < _height)
            {
                if (HasShip(new Coordinate(coordinates.XPos + 1, coordinates.YPos - 1)))
                {
                    return false;
                }
            }
            if (coordinates.YPos - 1 >= 0 && coordinates.XPos - 1 >= 0)
            {
                if (HasShip(new Coordinate(coordinates.XPos - 1, coordinates.YPos - 1)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

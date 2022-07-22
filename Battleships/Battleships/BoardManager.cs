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
                return board[coordinates.xPos][coordinates.yPos].hasShip;
            }
            throw new InvalidOperationException("Out of bounds");
        }
        public bool IsHit(Coordinate coordinates)
        {
            if (CheckPlacementBounds(coordinates))
            {
                return board[coordinates.xPos][coordinates.yPos].isHit;
            }
            throw new InvalidOperationException("Out of bounds");
        }
        public void HitSquare(Coordinate coordinates)
        {
            if (CheckPlacementBounds(coordinates) && !IsHit(coordinates))
            {
                board[coordinates.xPos][coordinates.yPos].isHit = true;
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
                    board[coordinates.xPos][coordinates.yPos].hasShip = true;
                    board[coordinates.xPos][coordinates.yPos].shipType = ship.Size;
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
                                    board[coordinates.xPos - i][coordinates.yPos].hasShip = true;
                                    board[coordinates.xPos - i][coordinates.yPos].shipType = ship.Size;

                                }
                                _placedShips++;
                                return true;
                            case "south":
                                for (int i = 0; i < ship.Size; i++)
                                {
                                    board[coordinates.xPos + i][coordinates.yPos].hasShip = true;
                                    board[coordinates.xPos + i][coordinates.yPos].shipType = ship.Size;
                                }
                                _placedShips++;
                                return true;
                            case "east":
                                for (int i = 0; i < ship.Size; i++)
                                {
                                    board[coordinates.xPos][coordinates.yPos + i].hasShip = true;
                                    board[coordinates.xPos][coordinates.yPos + i].shipType = ship.Size;
                                }
                                _placedShips++;
                                return true;
                            case "west":
                                for (int i = 0; i < ship.Size; i++)
                                {
                                    board[coordinates.xPos][coordinates.yPos - i].hasShip = true;
                                    board[coordinates.xPos][coordinates.yPos - i].shipType = ship.Size;
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
            if (ship.Direction == "north" && coordinates.xPos - ship.Size < 0)
            {
                return false;
            }
            else if (ship.Direction == "south" && coordinates.xPos + ship.Size >= _height)
            {
                return false;
            }
            else if (ship.Direction == "east" && coordinates.yPos + ship.Size >= _height)
            {
                return false;
            }
            else if (ship.Direction == "west" && coordinates.yPos - ship.Size < 0)
            {
                return false;
            }
            return true;
        }
        public bool CheckPlacementBounds(Coordinate coordinates)
        {
            if (coordinates.xPos < 0)
            {
                return false;
            }
            else if (coordinates.xPos >= _height)
            {
                return false;
            }
            else if (coordinates.yPos >= _height)
            {
                return false;
            }
            else if (coordinates.yPos < 0)
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
                    if (HasShip(new Coordinate(coordinates.xPos - i, coordinates.yPos)) || !CheckAdjacentSquares(new Coordinate(coordinates.xPos - i, coordinates.yPos)))
                    {
                        return false;
                    }
                }
                else if (ship.Direction == "south")
                {
                    if (HasShip(new Coordinate(coordinates.xPos + i, coordinates.yPos)) || !CheckAdjacentSquares(new Coordinate(coordinates.xPos + i, coordinates.yPos)))
                    {
                        return false;
                    }
                }
                else if (ship.Direction == "east")
                {
                    if (HasShip(new Coordinate(coordinates.xPos, coordinates.yPos + i)) || !CheckAdjacentSquares(new Coordinate(coordinates.xPos, coordinates.yPos + i)))
                    {
                        return false;
                    }
                }
                else if (ship.Direction == "west")
                {
                    if (HasShip(new Coordinate(coordinates.xPos, coordinates.yPos - i)) || !CheckAdjacentSquares(new Coordinate(coordinates.xPos, coordinates.yPos - i)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool CheckAdjacentSquares(Coordinate coordinates)
        {
            if (coordinates.xPos + 1 < _height)
            {
                if (HasShip(new Coordinate(coordinates.xPos + 1, coordinates.yPos)))
                {
                    return false;
                }
            }
            if (coordinates.xPos - 1 >= 0)
            {
                if (HasShip(new Coordinate(coordinates.xPos - 1, coordinates.yPos)))
                {
                    return false;
                }
            }
            if (coordinates.yPos + 1 < _width)
            {
                if (HasShip(new Coordinate(coordinates.xPos, coordinates.yPos + 1)))
                {
                    return false;
                }
            }
            if (coordinates.yPos - 1 >= 0)
            {
                if (HasShip(new Coordinate(coordinates.xPos, coordinates.yPos - 1)))
                {
                    return false;
                }
            }
            if (coordinates.yPos + 1 < _width && coordinates.xPos + 1 < _height)
            {
                if (HasShip(new Coordinate(coordinates.xPos + 1, coordinates.yPos + 1)))
                {
                    return false;
                }
            }
            if (coordinates.yPos + 1 < _width && coordinates.xPos - 1 >= 0)
            {
                if (HasShip(new Coordinate(coordinates.xPos - 1, coordinates.yPos + 1)))
                {
                    return false;
                }
            }
            if (coordinates.yPos - 1 >= 0 && coordinates.xPos + 1 < _height)
            {
                if (HasShip(new Coordinate(coordinates.xPos + 1, coordinates.yPos - 1)))
                {
                    return false;
                }
            }
            if (coordinates.yPos - 1 >= 0 && coordinates.xPos - 1 >= 0)
            {
                if (HasShip(new Coordinate(coordinates.xPos - 1, coordinates.yPos - 1)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

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
        public int shipType;

        public Cell(bool hasShip, int shipType)
        {
            this.hasShip = hasShip;
            this.shipType = shipType;
        }
    }
    public class BoardManager
    {
        private Cell[][] board;

        public Cell[][] Board => board;

        public BoardManager()
        {
            board = new Cell[10][];

            for (int i = 0; i < 10; i++)
            {
                board[i] = Enumerable.Repeat(new Cell(false, 0), 10).ToArray();
            }
        }

        public void PlaceShip(int i, int j)
        {
            board[i][j].hasShip = !HasShip(i, j) ? true : false;
        }

        public bool HasShip(int i, int j)
        {
            return board[i][j].hasShip;
        }


        public void RandomPlaceShip(int count, Target ship)
        {
            if (count > 100)
            {
                throw new InvalidOperationException("Count can not exceed total cell count, total cell count = 100!");
            }

            Random random = new Random(10);

            int shipCounter = 0;

            while (shipCounter < count)
            {
                if (TryPlaceShip(random.Next(0, 10), random.Next(0, 10), ship))
                {
                    shipCounter++;

                }
            }
        }

        public bool TryPlaceShip(int x, int y, Target ship)
        {
            if (ship.Size == 1)
            {
                if (HasShip(x, y) || !CheckAdjacentSquares(x, y))
                {
                    return false;
                }

                board[x][y].hasShip = true;
                board[x][y].shipType = ship.Size;
                return true;
            }
            else
            {
                if (ship.Direction == "north" && x - ship.Size < 0)
                {
                    return false;
                }
                else if (ship.Direction == "south" && x + ship.Size > 10)
                {
                    return false;
                }
                else if (ship.Direction == "east" && y + ship.Size > 10)
                {
                    return false;
                }
                else if (ship.Direction == "west" && y - ship.Size < 0)
                {
                    return false;
                }
                if (CheckNeighbors(x, y, ship))
                {
                    switch (ship.Direction)
                    {
                        case "north":
                            for (int i = 0; i < ship.Size; i++)
                            {
                                board[x - i][y].hasShip = true;
                                board[x - i][y].shipType = ship.Size;
                            }
                            return true;
                        case "south":
                            for (int i = 0; i < ship.Size; i++)
                            {
                                board[x + i][y].hasShip = true;
                                board[x + i][y].shipType = ship.Size;
                            }
                            return true;
                        case "east":
                            for (int i = 0; i < ship.Size; i++)
                            {
                                board[x][y + i].hasShip = true;
                                board[x][y + i].shipType = ship.Size;
                            }
                            return true;
                        case "west":
                            for (int i = 0; i < ship.Size; i++)
                            {
                                board[x][y - i].hasShip = true;
                                board[x][y - i].shipType = ship.Size;
                            }
                            return true;
                        default:
                            return false;
                    }
                }
                return false;
            }
        }
        public bool CheckNeighbors(int x, int y, Target ship)
        {
            for (int i = 0; i < ship.Size; i++)
            {
                if (ship.Direction == "north")
                {
                    if (HasShip(x - i, y) || !CheckAdjacentSquares(x - i, y))
                    {
                        return false;
                    }
                }
                else if (ship.Direction == "south")
                {
                    if (HasShip(x + i, y) || !CheckAdjacentSquares(x + i, y))
                    {
                        return false;
                    }
                }
                else if (ship.Direction == "east")
                {
                    if (HasShip(x, y + i) || !CheckAdjacentSquares(x, y + i))
                    {
                        return false;
                    }
                }
                else if (ship.Direction == "west")
                {
                    if (HasShip(x, y - i) || !CheckAdjacentSquares(x, y - i))
                    {
                        return false;
                    }
                }

            }

            return true;
        }
        public bool CheckAdjacentSquares(int x, int y)
        {
            if (x + 1 < 10)
            {
                if (HasShip(x + 1, y))
                {
                    return false;
                }
            }
            if (x - 1 >= 0)
            {
                if (HasShip(x - 1, y))
                {
                    return false;
                }
            }
            if (y + 1 < 10)
            {
                if (HasShip(x, y + 1))
                {
                    return false;
                }
            }
            if (y - 1 >= 0)
            {
                if (HasShip(x, y - 1))
                {
                    return false;
                }
            }
            if (y + 1 < 10 && x + 1 < 10)
            {
                if (HasShip(x + 1, y + 1))
                {
                    return false;
                }
            }
            if (y + 1 < 10 && x - 1 >= 0)
            {
                if (HasShip(x - 1, y + 1))
                {
                    return false;
                }
            }
            if (y - 1 >= 0 && x + 1 < 10)
            {
                if (HasShip(x + 1, y - 1))
                {
                    return false;
                }
            }
            if (y - 1 >= 0 && x - 1 >= 0)
            {
                if (HasShip(x - 1, y - 1))
                {
                    return false;
                }
            }

            return true;
        }



    }
}

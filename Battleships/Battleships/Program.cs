using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Battleships
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BoardRenderer boardRenderer = new BoardRenderer(10, 10);
            BoardManager boardManager = new BoardManager();
            boardManager.RandomPlaceShip(5);
            boardRenderer.Render(boardManager);
            Console.WriteLine("-----------------------------------------");
            boardManager.RandomPlaceShip(10);
            boardRenderer.Render(boardManager);
        }
    }
}

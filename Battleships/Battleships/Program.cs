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
            IConsole console = new SystemConsole();
            BoardRenderer boardRenderer = new BoardRenderer(10, 10);
            BoardManager playerBoard = new BoardManager(10, 10);
            BoardManager computerBoard = new BoardManager(10, 10);

            GameManager gameManager = new GameManager(console, playerBoard, computerBoard, boardRenderer);

            gameManager.play();
        }
    }
}

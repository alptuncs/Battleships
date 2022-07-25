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
            var boardRenderer = new BoardRenderer(10, 10);
            var playerBoard = new BoardManager(10, 10);
            var computerBoard = new BoardManager(10, 10);
            List<Target> targets = new List<Target>();
            Target amiralGemisi = new Target(4, Direction.East, "amiralGemisi");
            Target kruvazor = new Target(3, Direction.North, "kruvazor");
            Target mayinGemisi = new Target(2, Direction.East, "mayinGemisi");
            Target denizalti = new Target(1, Direction.North, "denizalti");

            targets.Add(amiralGemisi);
            targets.Add(kruvazor);
            targets.Add(mayinGemisi);
            targets.Add(denizalti);



            GameManager gameManager = new GameManager(console, playerBoard, computerBoard, boardRenderer, targets);

            GameSession gameSession = new GameSession(gameManager);

            gameSession.Play();
        }
    }
}

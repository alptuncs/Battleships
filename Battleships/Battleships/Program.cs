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
            List<Target> targets = new List<Target>();
            Target amiralGemisi = new Target(4, "east", "amiralGemisi");
            Target kruvazor = new Target(3, "north", "kruvazor");
            Target mayinGemisi = new Target(2, "east", "mayinGemisi");
            Target denizalti = new Target(1, "north", "denizalti");

            targets.Add(amiralGemisi);
            targets.Add(kruvazor);
            targets.Add(mayinGemisi);
            targets.Add(denizalti);



            GameManager gameManager = new GameManager(console, playerBoard, computerBoard, boardRenderer, targets);

            gameManager.Initialize();
            gameManager.Play();
        }
    }
}

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
            Target amiralGemisi = new Target(4, "east", "amiralGemisi");
            Target kruvazor = new Target(3, "north", "kruvazor");
            Target mayinGemisi = new Target(2, "east", "mayinGemisi");
            Target denizalti = new Target(1, "north", "denizalti");

            List<Target> targets = new List<Target>();
            targets.Add(amiralGemisi);
            targets.Add(kruvazor);
            targets.Add(mayinGemisi);
            targets.Add(denizalti);

            BoardRenderer boardRenderer = new BoardRenderer(10, 10);
            BoardManager playerBoard = new BoardManager(10, 10);
            BoardManager computerBoard = new BoardManager(10, 10);

            foreach (Target target in targets)
            {
                computerBoard.RandomPlaceShip(5 - target.Size, target);
            }

            playerBoard.PlaceShip(5, 5, kruvazor);

            GameManager gameManager = new GameManager(console, playerBoard, computerBoard, boardRenderer);

            gameManager.FireMissile(playerBoard, 5, 5);
            gameManager.FireMissile(computerBoard, 5, 5);
            gameManager.RenderGame();
        }
    }
}

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

            Target amiralGemisi = new Target(4, "east");
            Target kruvazor = new Target(3, "north");
            Target mayinGemisi = new Target(2, "east");
            Target denizalti = new Target(1, "north");

            List<Target> targets = new List<Target>();
            targets.Add(amiralGemisi);
            targets.Add(kruvazor);
            targets.Add(mayinGemisi);
            targets.Add(denizalti);

            BoardRenderer boardRenderer = new BoardRenderer(10, 10);
            BoardManager boardManager = new BoardManager(10, 10);
            boardRenderer.Render(boardManager);
            Console.WriteLine("-----------------------------------------");

            foreach (Target target in targets)
            {
                boardManager.RandomPlaceShip(5 - target.Size, target);
            }
            boardRenderer.Render(boardManager);

        }
    }
}

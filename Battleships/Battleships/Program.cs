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
            var targetFactory = new TargetFactory();
            List<ITarget> targets = new List<ITarget>();
            // ITarget amiralGemisi = targetFactory.Create(Direction.East(), "amiralgemisi");
            //ITarget kruvazor = targetFactory.Create(Direction.North(), "kruvazor");
            //ITarget mayinGemisi = targetFactory.Create(Direction.East(), "mayingemisi");
            ITarget denizalti = targetFactory.Create(Direction.North(), "denizalti");

            //targets.Add(amiralGemisi);
            //targets.Add(kruvazor);
            //targets.Add(mayinGemisi);
            targets.Add(denizalti);



            GameManager gameManager = new GameManager(console, playerBoard, computerBoard, boardRenderer, targets);

            GameSession gameSession = new GameSession(gameManager);

            gameSession.Play();
        }
    }
}

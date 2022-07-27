using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class GameManagerFactory
    {
        public GameManager Create()
        {
            IConsole console = new SystemConsole();
            var boardRenderer = new BoardRenderer(10, 10);
            var computerBoard = new BoardManagerFactory().Create(10, 10);
            var targetFactory = new TargetFactory();
            List<ITarget> targets = new List<ITarget>();
            ITarget amiralGemisi = targetFactory.Create(Direction.West(), "amiralgemisi");
            ITarget kruvazor = targetFactory.Create(Direction.North(), "kruvazor");
            ITarget mayinGemisi = targetFactory.Create(Direction.East(), "mayingemisi");
            ITarget denizalti = targetFactory.Create(Direction.North(), "denizalti");

            targets.Add(amiralGemisi);
            targets.Add(kruvazor);
            targets.Add(mayinGemisi);
            targets.Add(denizalti);

            return new GameManager(console, computerBoard, boardRenderer, targets);

        }
    }
}

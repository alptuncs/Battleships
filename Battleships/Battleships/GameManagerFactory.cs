using System.Collections.Generic;

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
            List<Target> targets = new()
            {
                targetFactory.Create(Direction.West(), "Battleship"),
                targetFactory.Create(Direction.North(), "Cruiser"),
                targetFactory.Create(Direction.East(), "Destroyer"),
                targetFactory.Create(Direction.North(), "Submarine")
            };

            return new GameManager(console, computerBoard, boardRenderer, targets);
        }
    }
}

using System.Collections.Generic;

namespace Battleships;

public class GameManagerFactory
{
    public GameManager Create(IGameUserInterface<IBattleshipGameObjectFactory> userInterface)
    {
        var computerBoard = BoardFactory.Create(10, 10);
        var player = new Player(30, 0);
        var targetFactory = new TargetFactory();
        List<Target> targets = new()
        {
            targetFactory.Create(Direction.West(), "Battleship"),
            targetFactory.Create(Direction.North(), "Cruiser"),
            targetFactory.Create(Direction.East(), "Cruiser"),
            targetFactory.Create(Direction.South(), "Destroyer"),
            targetFactory.Create(Direction.West(), "Destroyer"),
            targetFactory.Create(Direction.North(), "Destroyer"),
            targetFactory.Create(Direction.East(), "Submarine"),
            targetFactory.Create(Direction.South(), "Submarine"),
            targetFactory.Create(Direction.West(), "Submarine"),
            targetFactory.Create(Direction.North(), "Submarine")
        };

        return new GameManager(computerBoard, targets, player, userInterface);
    }
}

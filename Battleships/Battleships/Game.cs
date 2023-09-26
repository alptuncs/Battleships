using System.Collections.Generic;

namespace Battleships;

public class Game
{
    private readonly IGameUserInterface<IBattleshipGameObjectFactory> gameUserInterface;

    public IGameUserInterface<IBattleshipGameObjectFactory> GameUserInterface => gameUserInterface;

    public Board Board { get; private set; }
    public List<Target> Targets { get; private set; }
    public Player Player { get; private set; }
    public InputCheck InputCheck { get; private set; }

    public Game(Board board, List<Target> targets, Player player, IGameUserInterface<IBattleshipGameObjectFactory> gameUserInterface)
    {
        Board = board;
        Targets = targets;
        Player = player;
        this.gameUserInterface = gameUserInterface;
        InputCheck = new InputCheck(board);
    }

    public void Initialize()
    {
        gameUserInterface.ShowMessage("");
        foreach (Target target in Targets)
        {
            Board.PlaceShip(1, target);
        }
    }

    public void OnFireMissile(Coordinate coordinate)
    {
        var inputCheckResult = InputCheck.GetInputResult(coordinate);
        if (inputCheckResult == string.Empty)
        {
            FireMissile(coordinate);
        }
        else
        {
            gameUserInterface.ShowMessage(inputCheckResult);
        }

    }

    private void FireMissile(Coordinate coordinate)
    {
        if (Board[coordinate].IsHit || !Board[coordinate].HasShip)
        {
            gameUserInterface.ShowMessage(Board[coordinate].IsHit ? Messages.SAME_COORD : Messages.HIT_MISSED);
            Player.DecreaseLives();
        }
        else
        {
            Player.IncreaseScore(100);
            Board.RemoveShip(coordinate);
            gameUserInterface.ShowMessage(Messages.HIT_SUCCESS);
        }

        Board[coordinate].HitSquare();
    }

    public bool ShouldRun()
    {
        if (!Player.HasLives)
        {
            gameUserInterface.ShowMessage(Messages.OUT_OF_LIVES);

            return false;
        }
        else if (Board.ShipCoordinates.Count == 0)
        {
            gameUserInterface.ShowMessage(Messages.YOU_WON);

            return false;
        }
        else
        {
            gameUserInterface.ShowMessage(Messages.ENTER_COORDS);

            return true;
        }
    }

    public void RenderGame()
    {
        gameUserInterface.Status.Clear();
        gameUserInterface.Status.Add(new("Lives", $"{Player.Lives}"));
        gameUserInterface.Status.Add(new("Score", $"{Player.Score}"));

        gameUserInterface.Draw(gameUserInterface.GameObjectFactory.CreateBoard(Board.Width, Board.Height), new Coordinate(0, 0));
    }
}

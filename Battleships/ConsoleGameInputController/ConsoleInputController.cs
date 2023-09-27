namespace Battleships;

public class ConsoleInputController : IBattleShipInputController
{
    public Game Game { get; private set; } = default!;

    public void AddGame(Game game)
    {
        Game = game;
    }

    public void RegisterFireMissileEvent(Coordinate coordinate) =>
        Game.OnFireMissile(coordinate);
}

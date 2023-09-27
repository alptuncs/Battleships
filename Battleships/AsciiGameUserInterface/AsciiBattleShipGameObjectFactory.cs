namespace Battleships;

public class AsciiBattleShipGameObjectFactory : IBattleshipGameObjectFactory
{
    public IGameObject CreateBoard(int width, int height) =>
        new AsciiBoard(width, height);

    public IGameObject CreateShip(bool[] status, Direction direction) =>
        new AsciiShip(status, direction);
    public IGameObject CreateMiss() =>
        new AsciiMiss();
}

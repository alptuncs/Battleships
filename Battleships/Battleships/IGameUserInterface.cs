using System.Collections.Generic;

namespace Battleships;

public interface IGameUserInterface<TGameObjectFactory> where TGameObjectFactory : IGameObjectFactory
{
    TGameObjectFactory GameObjectFactory { get; }
    List<StatusField> Status { get; }
    void ShowMessage(string text);
    void Draw(IGameObject gameObject, Coordinate coordinate);
}

public class StatusField
{
    public string Value { get; }
    public string Label { get; }

    public StatusField(string label, string value)
    {
        Label = label;
        Value = value;
    }
}

public interface IGameObject { }

public interface IGameObjectFactory { }

public interface IGameInputController { }

public interface IBattleshipGameObjectFactory : IGameObjectFactory
{
    IGameObject CreateShip(bool[] status, Direction direction);
    IGameObject CreateBoard(int width, int height);
    IGameObject CreateMiss();
}

public interface IBattleShipInputController : IGameInputController
{
    public Game? Game { get; }
    void AddGame(Game game);
    void RegisterFireMissileEvent(Coordinate coordinate);
}

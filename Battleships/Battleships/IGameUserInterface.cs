using System;
using System.Collections.Generic;
using System.Linq;

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

public interface IBalleshipGameInputController : IGameInputController
{
    public Game? Game { get; }
    void AddGame(Game game);
    void RegisterFireMissileEvent(Action<Coordinate> action);
}

public class ConsoleGameInputController : IBalleshipGameInputController
{
    public Game? Game { get; private set; }

    public void AddGame(Game game)
    {
        Game = game;
    }

    public void RegisterFireMissileEvent(Action<Coordinate> action)
    {
        throw new NotImplementedException();
    }
}

public class AsciiGameUserInterface<TGameObjectFactory> : IGameUserInterface<TGameObjectFactory> where TGameObjectFactory : IGameObjectFactory
{
    private readonly IConsole console;
    private readonly char[,] screen;

    private string message;

    public List<StatusField> Status => new();

    public TGameObjectFactory GameObjectFactory { get; }
    public IGameInputController GameInputController { get; }

    public AsciiGameUserInterface(IConsole console, int width, int height, TGameObjectFactory gameObjectFactory, IBalleshipGameInputController gameInputController)
    {
        this.console = console;
        this.screen = new char[width, height];

        GameObjectFactory = gameObjectFactory;
        GameInputController = gameInputController;
    }

    public void Draw(IGameObject gameObject, Coordinate coordinate)
    {
        if (gameObject is not IAsciiGameObject asciiGameObject) { return; }

        var graphics = asciiGameObject.Graphics;

        for (int x = 0; x < graphics.GetLength(0); x++)
        {
            for (int y = 0; y < graphics.GetLength(1); y++)
            {
                screen[x + coordinate.XPos, y + coordinate.YPos] = graphics[x, y];
            }
        }
    }

    public void ShowMessage(string text) =>
        message = text;

    public void Paint()
    {
        console.Clear();

        console.WriteLine(message);

        for (int x = 0; x < screen.GetLength(0); x++)
        {
            for (int y = 0; y < screen.GetLength(1); y++)
            {
                if (screen[x, y] is default(char)) { continue; }

                console.Write(screen[x, y]);
                screen[x, y] = default;
            }

            console.WriteLine("");
        }

        console.WriteLine(string.Join(" | ", Status.Select(s => $"{s.Label} : {s.Value}")));
    }
}

public interface IAsciiGameObject : IGameObject
{
    char[,] Graphics { get; }
}

public class AsciiBattleShipGameObjectFactory : IBattleshipGameObjectFactory
{
    public IGameObject CreateBoard(int width, int height) =>
        new AsciiBoard(width, height);

    public IGameObject CreateShip(bool[] status, Direction direction) =>
        new AsciiShip(status, direction);
    public IGameObject CreateMiss() =>
        new AsciiMiss();
}

public class AsciiBoard : IAsciiGameObject
{
    private int width;
    private int height;

    public AsciiBoard(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public char[,] Graphics => throw new NotImplementedException();
}

public class AsciiShip : IAsciiGameObject
{
    private Direction direction;

    public AsciiShip(bool[] status, Direction direction)
    {
        Status = status;
        this.direction = direction;
    }

    public bool[] Status { get; }

    public char[,] Graphics => throw new NotImplementedException();
}

public class AsciiMiss : IAsciiGameObject
{
    public char[,] Graphics => throw new NotImplementedException();
}

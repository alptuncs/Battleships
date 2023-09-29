namespace Battleships;

public interface IAsciiGameObject : IGameObject
{
    char[,] Graphics { get; }
}

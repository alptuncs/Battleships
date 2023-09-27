namespace Battleships;

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

namespace Battleships
{
    public interface ITarget
    {
        int Size { get; }
        Direction Direction { get; }

        void SetShipDirection(Direction direction);
    }
}

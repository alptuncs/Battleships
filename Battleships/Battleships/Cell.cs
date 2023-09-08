namespace Battleships
{
    public class Cell
    {
        public ITarget Ship { get; private set; }
        public bool IsHit { get; private set; }

        public bool HasShip => Ship is not null;

        public void HitSquare() => IsHit = true;
        public void PlaceShip(ITarget ship) => Ship = ship;
    }
}

namespace Battleships;

public class Cell
{
    public Target? Ship { get; private set; }
    public bool IsHit { get; private set; }

    public bool HasShip => Ship is not null;

    public void HitSquare() => IsHit = true;
    public void PlaceShip(Target ship) => Ship = ship;
}

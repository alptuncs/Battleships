namespace Battleships;

public class TargetFactory
{
    public Target Create(Direction direction, string shipType)
    {
        if (shipType == "Submarine")
        {
            return new(1, direction);
        }
        else if (shipType == "Destroyer")
        {
            return new(2, direction);
        }
        else if (shipType == "Cruiser")
        {
            return new(3, direction);
        }
        else if (shipType == "Battleship")
        {
            return new(4, direction);
        }

        throw new System.Exception("No such ship");
    }
}

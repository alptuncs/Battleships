namespace Battleships
{
    public class TargetFactory
    {
        public ITarget Create(Direction direction, string shipType)
        {
            ITarget target = null;
            if (shipType == "denizalti")
            {
                target = new Submarine();
            }
            else if (shipType == "mayingemisi")
            {
                target = new Minelayer();
            }
            else if (shipType == "kruvazor")
            {
                target = new Destroyer();
            }
            else
            {
                target = new Flagship();
            }

            target.SetShipDirection(direction);
            return target;
        }
    }
}

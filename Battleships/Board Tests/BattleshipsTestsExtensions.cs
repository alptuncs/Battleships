using Battleships;

namespace Board_Tests;

public static class BattleshipsTestsExtensions
{
    public static BoardManager ABoardManager(this Spec.Stubber _, int height, int width) =>
        new BoardManagerFactory().Create(height, width);

    public static ITarget ATarget(this Spec.Stubber _, Direction direction = default, string shipType = default) =>
        new TargetFactory().Create(direction ?? Direction.East(), shipType ?? "denizalti");

    public static Coordinate ACoordinate(this Spec.Stubber _, int xCoordinate, int yCoordinate) =>
        new Coordinate(xCoordinate, yCoordinate);
}

using Battleships;

namespace Board_Tests;

public static class BattleshipsTestsExtensions
{
    public static BoardManager ABoardManager(this Spec.Stubber _, int height = default, int width = default) =>
        new BoardManagerFactory().Create(height == default ? 10 : height, width == default ? 10 : width);

    public static ITarget ATarget(this Spec.Stubber _, Direction direction = default, string shipType = default) =>
        new TargetFactory().Create(direction ?? Direction.East(), shipType ?? "denizalti");

    public static Coordinate ACoordinate(this Spec.Stubber _, int xCoordinate, int yCoordinate) =>
        new(xCoordinate, yCoordinate);

    public static BoardRenderer ABoardRenderer(this Spec.Stubber _, int height = default, int width = default) =>
        new(height == default ? 10 : height, width == default ? 10 : width);

    public static List<ITarget> ATargetList(this Spec.Stubber giveMe, int numTargets = default) =>
        Enumerable.Repeat(giveMe.ATarget(), numTargets == default ? 5 : numTargets).ToList();

    public static IConsole AConsole(this Spec.Stubber _) =>
        new SystemConsole();

    public static GameManager AGameManager(this Spec.Stubber giveMe,
        int height = default,
        int width = default,
        int numTargets = default,
        List<ITarget> targetList = default
    ) => new(
            giveMe.AConsole(),
            giveMe.ABoardManager(height, width),
            giveMe.ABoardRenderer(height, width),
            targetList ?? giveMe.ATargetList(numTargets)
    );
}

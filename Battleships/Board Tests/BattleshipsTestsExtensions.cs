using Battleships;

namespace Board_Tests;

public static class BattleshipsTestsExtensions
{
    public static BoardManager ABoardManager(this Spec.Stubber giveMe, int height = default, int width = default, bool? withShips = false) =>
        withShips == false ? giveMe.Empty(height, width) : giveMe.WithShip(height, width);

    private static BoardManager WithShip(this Spec.Stubber giveMe, int height, int width)
    {
        var board = giveMe.Empty(height, width);
        board.PlaceShip(giveMe.ACoordinate(0, 0), giveMe.ATarget());

        return board;
    }
    private static BoardManager Empty(this Spec.Stubber _, int height, int width) =>
        new BoardManagerFactory().Create(height == default ? 10 : height, width == default ? 10 : width);

    public static Cell ACell(this Spec.Stubber giveMe) =>
        giveMe.ABoardManager()[giveMe.ACoordinate()];

    public static Target ATarget(this Spec.Stubber _, Direction? direction = default, string? shipType = default) =>
        new TargetFactory().Create(direction ?? Direction.East(), shipType ?? "Submarine");

    public static Coordinate ACoordinate(this Spec.Stubber _, int xCoordinate = 2, int yCoordinate = 5) =>
        new(xCoordinate, yCoordinate);

    public static BoardRenderer ABoardRenderer(this Spec.Stubber _, int height = default, int width = default) =>
        new(height == default ? 10 : height, width == default ? 10 : width);

    public static List<Target> ATargetList(this Spec.Stubber giveMe, int numTargets = default, bool? empty = false) =>
        empty == true ? new() : Enumerable.Repeat(giveMe.ATarget(), numTargets == default ? 5 : numTargets).ToList();

    public static IConsole AConsole(this Spec.Stubber _) =>
        new SystemConsole();

    public static GameManager AGameManager(this Spec.Stubber giveMe,
        int height = default,
        int width = default,
        int numTargets = default,
        List<Target>? targetList = default,
        BoardManager? board = default
    ) => new(
            giveMe.AConsole(),
            board ?? giveMe.ABoardManager(height, width),
            giveMe.ABoardRenderer(height, width),
            targetList ?? giveMe.ATargetList(numTargets)
    );
}

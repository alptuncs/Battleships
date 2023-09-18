using Battleships;
using Moq;

namespace Board_Tests;

public static class BattleshipsTestsExtensions
{
    public static Board ABoard(this Spec.Stubber giveMe, int height = default, int width = default, bool withShips = false) =>
        withShips ? giveMe.WithShip(height, width) : giveMe.Empty(height, width);

    private static Board WithShip(this Spec.Stubber giveMe, int height, int width)
    {
        var board = giveMe.Empty(height, width);
        board.PlaceShip(giveMe.ACoordinate(0, 0), giveMe.ATarget());

        return board;
    }
    private static Board Empty(this Spec.Stubber _, int height, int width) =>
        BoardFactory.Create(height == default ? 10 : height, width == default ? 10 : width);

    public static Cell ACell(this Spec.Stubber giveMe) =>
        giveMe.ABoard()[giveMe.ACoordinate()];

    public static Target ATarget(this Spec.Stubber _, Direction? direction = default, string? shipType = default) =>
        new TargetFactory().Create(direction ?? Direction.East(), shipType ?? "Submarine");

    public static Coordinate ACoordinate(this Spec.Stubber _, int xCoordinate = 2, int yCoordinate = 5) =>
        new(xCoordinate, yCoordinate);

    public static BoardRenderer ABoardRenderer(this Spec.Stubber _, int height = default, int width = default) =>
        new(height == default ? 10 : height, width == default ? 10 : width);

    public static List<Target> ATargetList(this Spec.Stubber giveMe, int numTargets = default, bool empty = false) =>
        empty == true ? new() : Enumerable.Repeat(giveMe.ATarget(), numTargets == default ? 5 : numTargets).ToList();

    public static Player APlayer(this Spec.Stubber _, int lives = default, int score = default) =>
        new Player(lives == default ? 0 : lives, score == default ? 0 : score);

    public static IConsole AConsole(this Spec.Mocker _, string input = "A,1")
    {
        var result = new Mock<IConsole>();

        result.Setup(c => c.ReadLine()).Returns(input);
        result.Setup(c => c.Clear());

        return result.Object;
    }

    public static GameManager AGameManager(this Spec.Stubber giveMe,
        IConsole? console = default,
        int height = default,
        int width = default,
        Board? board = default,
        int numTargets = default,
        List<Target>? targetList = default,
        Player? player = default
    ) => new(
            console ?? giveMe.Spec.MockMe.AConsole(),
            board ?? giveMe.ABoard(height, width),
            giveMe.ABoardRenderer(height, width),
            targetList ?? giveMe.ATargetList(numTargets),
            player ?? giveMe.APlayer(30, 0)
    );

    public static GameSession AGameSession(this Spec.Stubber giveMe, GameManager? gameManager = default) =>
        new GameSession(gameManager ?? giveMe.AGameManager());
}

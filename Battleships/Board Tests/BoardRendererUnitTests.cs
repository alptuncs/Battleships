using Battleships;
using NUnit.Framework;

namespace Board_Tests;

[TestFixture]
public class BoardRendererUnitTests : Spec
{
    [Test]
    public void BoardRenderer_renders_the_board_with_given_height_and_width()
    {
        BoardRenderer testBoard = GiveMe.ABoardRenderer(2, 2);

        testBoard.InitializeBoardGraphicString();

        Assert.AreEqual("  1  2\nA[ ][ ]\nB[ ][ ]", testBoard.BoardGraphicString);
    }

    [Test]
    public void BoardRenderer_renders_the_targets_BoardManager_places()
    {
        BoardRenderer testBoardRenderer = GiveMe.ABoardRenderer(2, 2);
        BoardManager testBoardManager = GiveMe.ABoardManager(2, 2);
        testBoardManager.PlaceShip(GiveMe.ACoordinate(1, 1), GiveMe.ATarget(Direction.North(), "denizalti"));

        testBoardRenderer.Render(testBoardManager, false);

        Assert.AreEqual("  1  2\nA[ ][ ]\nB[ ][1]", testBoardRenderer.BoardGraphicString);
    }
}

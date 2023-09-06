using Battleships;
using NUnit.Framework;

namespace Board_Tests;

[TestFixture]
public class BoardRendererUnitTests
{
    [Test]
    public void Verilen_boyutlarda_oyun_tahtasini_ekrana_cizer()
    {
        BoardRenderer testBoard = new BoardRenderer(2, 2);
        string expectedBoardGraphicString = "  1  2\nA[ ][ ]\nB[ ][ ]";

        testBoard.InitializeBoardGraphicString();

        Assert.AreEqual(expectedBoardGraphicString, testBoard.BoardGraphicString);
    }

    [Test]
    public void Verilen_boyutlarda_oyun_tahtasini_render_ile_ekrana_cizer()
    {
        BoardRenderer testBoardRenderer = new BoardRenderer(2, 2);
        BoardManager testBoardManager = new BoardManagerFactory().Create(2, 2);
        var targetFactory = new TargetFactory();
        ITarget ship = targetFactory.Create(Direction.North(), "denizalti");

        string expectedBoardGraphicString = "  1  2\nA[ ][ ]\nB[ ][1]";
        expectedBoardGraphicString = expectedBoardGraphicString.Substring(0, expectedBoardGraphicString.Length);

        testBoardManager.PlaceShip(new Coordinate(1, 1), ship);

        testBoardRenderer.Render(testBoardManager, false);

        Assert.AreEqual(expectedBoardGraphicString, testBoardRenderer.BoardGraphicString);
    }
}

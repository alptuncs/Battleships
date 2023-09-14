using NUnit.Framework;
using Shouldly;

namespace Board_Tests;

[TestFixture]
public class Rendering : Spec
{
    [Test]
    public void Renders_the_board_with_given_height_and_width()
    {
        Battleships.BoardRenderer testBoard = GiveMe.ABoardRenderer(2, 2);

        testBoard.InitializeBoardGraphicString();

        testBoard.BoardGraphicString.ShouldBe("  1  2\nA[ ][ ]\nB[ ][ ]");
    }
}

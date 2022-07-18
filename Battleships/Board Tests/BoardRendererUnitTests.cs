using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Board_Tests
{
    [TestClass]
    public class BoardRendererUnitTests
    {
        [TestMethod]
        public void BoardTest2x3()
        {
            // Arrange
            BoardRenderer testBoard = new BoardRenderer(2, 3);
            string[][] expectedBoard = new string[2][];

            expectedBoard[0] = new string[] { "[ ]", "[ ]", "[ ]" };
            expectedBoard[1] = new string[] { "[ ]", "[ ]", "[ ]" };

            // Act

            // Assert

            Assert.AreEqual(expectedBoard[0][0], testBoard.BoardSurface[0][0]);
            Assert.AreEqual(expectedBoard[0][1], testBoard.BoardSurface[0][1]);
            Assert.AreEqual(expectedBoard[0][2], testBoard.BoardSurface[0][2]);
            Assert.AreEqual(expectedBoard[1][0], testBoard.BoardSurface[1][0]);
            Assert.AreEqual(expectedBoard[1][1], testBoard.BoardSurface[1][1]);
            Assert.AreEqual(expectedBoard[1][2], testBoard.BoardSurface[1][2]);
        }

        [TestMethod]
        public void BoardTest3x2()
        {
            BoardRenderer testBoard = new BoardRenderer(3, 2);
            string[][] expectedBoard = new string[3][];

            expectedBoard[0] = new string[] { "[ ]", "[ ]" };
            expectedBoard[1] = new string[] { "[ ]", "[ ]" };
            expectedBoard[2] = new string[] { "[ ]", "[ ]" };

            // Act

            // Assert
            Assert.AreEqual(expectedBoard[0][0], testBoard.BoardSurface[0][0]);
            Assert.AreEqual(expectedBoard[0][1], testBoard.BoardSurface[0][1]);
            Assert.AreEqual(expectedBoard[1][0], testBoard.BoardSurface[1][0]);
            Assert.AreEqual(expectedBoard[1][1], testBoard.BoardSurface[1][1]);
            Assert.AreEqual(expectedBoard[2][0], testBoard.BoardSurface[2][0]);
            Assert.AreEqual(expectedBoard[2][1], testBoard.BoardSurface[2][1]);
        }

        [TestMethod]
        public void PrintTest2x2()
        {
            BoardRenderer testBoard = new BoardRenderer(2, 2);
            string expectedBoardGraphicString = "[ ] [ ]\n[ ] [ ]";

            testBoard.Print();

            Assert.AreEqual(expectedBoardGraphicString, testBoard.BoardGraphicString);
        }

        [TestMethod]
        public void PrintTest5x5()
        {
            BoardRenderer testBoard = new BoardRenderer(5, 5);
            string expectedBoardGraphicString = string.Concat(Enumerable.Repeat("[ ] [ ] [ ] [ ] [ ]\n", 5));
            expectedBoardGraphicString = expectedBoardGraphicString.Substring(0, expectedBoardGraphicString.Length - 1);


            testBoard.Print();

            Assert.AreEqual(expectedBoardGraphicString, testBoard.BoardGraphicString);
        }

        [TestMethod]
        public void RenderTest()
        {
            BoardRenderer testBoardRenderer = new BoardRenderer(2, 2);
            BoardManager testBoardManager = new BoardManager(2, 2);
            Target denizalti = new Target(1, "north");

            string expectedBoardGraphicString = @"[1] [ ]
[ ] [ ]";
            expectedBoardGraphicString = expectedBoardGraphicString.Substring(0, expectedBoardGraphicString.Length);

            testBoardManager.PlaceShip(1, 1, denizalti);


            testBoardRenderer.Render(testBoardManager);


            Assert.AreEqual(expectedBoardGraphicString, testBoardRenderer.BoardGraphicString);

        }
    }
}

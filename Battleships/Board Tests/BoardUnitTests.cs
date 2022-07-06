using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Board_Tests
{
    [TestClass]
    public class BoardUnitTests
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
            for (int i = 0; i < expectedBoard.Length; i++)
            {
                for (int j = 0; j < expectedBoard[0].Length; j++)
                {
                    Assert.AreEqual(expectedBoard[i][j], testBoard.BoardSurface[i][j]);
                }
            }
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
            for (int i = 0; i < expectedBoard.Length; i++)
            {
                for (int j = 0; j < expectedBoard[0].Length; j++)
                {
                    Assert.AreEqual(expectedBoard[i][j], testBoard.BoardSurface[i][j]);
                }
            }
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
            BoardRenderer testBoardRenderer = new BoardRenderer(10, 10);
            BoardManager testBoardManager = new BoardManager();

            string expectedBoardGraphicString = string.Concat(Enumerable.Repeat("[X] [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]\n", 10));
            expectedBoardGraphicString = expectedBoardGraphicString.Substring(0, expectedBoardGraphicString.Length - 1);

            testBoardManager.PlaceShip(0, 0);
            testBoardManager.PlaceShip(1, 0);
            testBoardManager.PlaceShip(2, 0);
            testBoardManager.PlaceShip(3, 0);
            testBoardManager.PlaceShip(4, 0);
            testBoardManager.PlaceShip(5, 0);
            testBoardManager.PlaceShip(6, 0);
            testBoardManager.PlaceShip(7, 0);
            testBoardManager.PlaceShip(8, 0);
            testBoardManager.PlaceShip(9, 0);

            testBoardRenderer.Render(testBoardManager);


            Assert.AreEqual(expectedBoardGraphicString, testBoardRenderer.BoardGraphicString);

        }
    }
}

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
            Board testBoard = new Board(2, 3);
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
            Board testBoard = new Board(3, 2);
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
            Board testBoard = new Board(2, 2);
            string expectedBoardGraphicString = "[ ] [ ]\n[ ] [ ]";

            testBoard.Print();

            Assert.AreEqual(expectedBoardGraphicString, testBoard.BoardGraphicString);
        }

        [TestMethod]
        public void PrintTest5x5()
        {
            Board testBoard = new Board(5, 5);
            string expectedBoardGraphicString = string.Concat(Enumerable.Repeat("[ ] [ ] [ ] [ ] [ ]\n", 5));
            expectedBoardGraphicString = expectedBoardGraphicString.Substring(0, expectedBoardGraphicString.Length - 1);


            testBoard.Print();

            Assert.AreEqual(expectedBoardGraphicString, testBoard.BoardGraphicString);
        }
    }
}

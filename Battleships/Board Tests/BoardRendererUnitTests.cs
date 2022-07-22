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
        public void Verilen_Boyutlarda_Oyun_Tahtası_Ekrana_Cizer()
        {
            BoardRenderer testBoard = new BoardRenderer(2, 2);
            string expectedBoardGraphicString = "[ ] [ ]\n[ ] [ ]";

            testBoard.InitializeBoardGraphicString();

            Assert.AreEqual(expectedBoardGraphicString, testBoard.BoardGraphicString);
        }


        [TestMethod]
        public void Verilen_Boyutlarda_Oyun_Tahtasini_Render_Fonksiyonu_ile_Ekrana_Cizer()
        {
            var testBoardRenderer = new BoardRenderer(2, 2);
            var testBoardManager = new BoardManager(2, 2);
            var denizalti = new Target(1, "north", "denizalti");

            string expectedBoardGraphicString = "[ ] [ ]\n[ ] [1]";
            expectedBoardGraphicString = expectedBoardGraphicString.Substring(0, expectedBoardGraphicString.Length);

            testBoardManager.PlaceShip(new Coordinate(1, 1), denizalti);

            testBoardRenderer.Render(testBoardManager, false);

            Assert.AreEqual(expectedBoardGraphicString, testBoardRenderer.BoardGraphicString);

        }
    }
}

using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Board_Tests
{
    [TestClass]
    public class BoardRendererUnitTests
    {


        [TestMethod]
        public void Verilen_Boyutlarda_Oyun_Tahtası_Ekrana_Cizer()
        {
            BoardRenderer testBoard = new BoardRenderer(2, 2);
            string expectedBoardGraphicString = "  1  2\nA[ ][ ]\nB[ ][ ]";

            testBoard.InitializeBoardGraphicString();

            Assert.AreEqual(expectedBoardGraphicString, testBoard.BoardGraphicString);
        }


        [TestMethod]
        public void Verilen_Boyutlarda_Oyun_Tahtasini_Render_Fonksiyonu_ile_Ekrana_Cizer()
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
}

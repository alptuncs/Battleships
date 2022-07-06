using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Board_Tests
{
    [TestClass]
    public class BoardManagerUnitTests
    {
        [TestMethod]
        public void HasShipTest()
        {
            BoardManager boardManager = new BoardManager();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Assert.IsFalse(boardManager.HasShip(i, j));
                }
            }

        }

        [TestMethod]
        public void PlaceShipTest()
        {
            BoardManager boardManager = new BoardManager();

            boardManager.PlaceShip(3, 2);

            Assert.IsTrue(boardManager.HasShip(3, 2));
            Assert.IsFalse(boardManager.HasShip(5, 5));
        }

        [TestMethod]
        public void RandomPlaceShipTest()
        {
            BoardManager boardManager = new BoardManager();
            boardManager.RandomPlaceShip(5);

            int counter = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (boardManager.HasShip(i, j))
                    {
                        counter++;
                    }
                }
            }

            Assert.AreEqual(counter, 5);
        }

        [TestMethod]
        public void RandomPlaceShipTest2()
        {
            BoardManager boardManager = new BoardManager();
            boardManager.RandomPlaceShip(5);
            boardManager.RandomPlaceShip(10);

            int counter = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (boardManager.HasShip(i, j))
                    {
                        counter++;
                    }
                }
            }

            Assert.AreEqual(counter, 15);
        }

        [TestMethod]

        public void MaxShipCountTestExceptionTest()
        {
            BoardManager boardManager = new BoardManager();

            try
            {
                boardManager.RandomPlaceShip(105);
                Assert.Fail("no exception thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is InvalidOperationException);
            }



        }
    }
}

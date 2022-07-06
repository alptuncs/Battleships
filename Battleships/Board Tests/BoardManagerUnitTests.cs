using Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
            Target amiralGemisi = new Target(4, "east");
            Target kruvazor = new Target(3, "north");
            Target mayinGemisi = new Target(2, "east");
            Target denizalti = new Target(1, "north");

            List<Target> targets = new List<Target>();
            targets.Add(amiralGemisi);
            targets.Add(kruvazor);
            targets.Add(mayinGemisi);
            targets.Add(denizalti);

            foreach (Target target in targets)
            {
                boardManager.RandomPlaceShip(5 - target.Size, target);
            }

            int amiralGemisiCounter = 0;
            int kruvazorCounter = 0;
            int mayinGemisiCounter = 0;
            int denizaltiCounter = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (boardManager.HasShip(i, j))
                    {
                        switch (boardManager.Board[i][j].shipType)
                        {
                            case 1:
                                denizaltiCounter++;
                                break;
                            case 2:
                                mayinGemisiCounter++;
                                break;
                            case 3:
                                kruvazorCounter++;
                                break;
                            case 4:
                                amiralGemisiCounter++;
                                break;
                            default:
                                break;
                        }

                    }
                }

            }

            Assert.AreEqual(denizaltiCounter, 4);
            Assert.AreEqual(mayinGemisiCounter, 6);
            Assert.AreEqual(kruvazorCounter, 6);
            Assert.AreEqual(amiralGemisiCounter, 4);
        }

        [TestMethod]

        public void MaxShipCountTestExceptionTest()
        {
            BoardManager boardManager = new BoardManager();
            Target kruvazor = new Target(3, "north");

            try
            {
                boardManager.RandomPlaceShip(105, kruvazor);
                Assert.Fail("no exception thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is InvalidOperationException);
            }



        }
    }
}

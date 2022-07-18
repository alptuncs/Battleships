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
            BoardManager boardManager = new BoardManager(10, 10);

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
            BoardManager boardManager = new BoardManager(10, 10);
            Target amiralGemisi = new Target(4, "east");

            boardManager.PlaceShip(3, 2, amiralGemisi);

            Assert.IsTrue(boardManager.HasShip(3, 2));
            Assert.IsTrue(boardManager.HasShip(3, 3));
            Assert.IsTrue(boardManager.HasShip(3, 4));
            Assert.IsTrue(boardManager.HasShip(3, 5));
            Assert.IsFalse(boardManager.HasShip(5, 5));
        }

        [TestMethod]
        public void RandomPlaceShipTest()
        {
            BoardManager boardManager = new BoardManager(10, 10);
            Target amiralGemisi = new Target(4, "east", "amiralGemisi");
            Target kruvazor = new Target(3, "north", "kruvazor");
            Target mayinGemisi = new Target(2, "east", "mayinGemisi");
            Target denizalti = new Target(1, "north", "denizalti");

            List<Target> targets = new List<Target>();
            targets.Add(amiralGemisi);
            targets.Add(kruvazor);
            targets.Add(mayinGemisi);
            targets.Add(denizalti);

            foreach (Target target in targets)
            {
                boardManager.RandomPlaceShip(5 - target.Size, target);
            }

            Assert.AreEqual(boardManager.PlacedShips, 10);
        }

        [TestMethod]

        public void Kapaisteden_fazla_gemi_eklenince_exception_atar()
        {
            BoardManager boardManager = new BoardManager(10, 10);
            Target kruvazor = new Target(3, "north", "kruvazor");

            Assert.ThrowsException<InvalidOperationException>(() => boardManager.RandomPlaceShip(105, kruvazor));


        }
    }
}

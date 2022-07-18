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
        public void PlaceShip_Gemiyi_Dogru_Koordinatta_Yerlestirmeye_Baslar()
        {
            BoardManager boardManager = new BoardManager(10, 10);
            Target amiralGemisi = new Target(4, "east", "amiralGemisi");

            boardManager.PlaceShip(3, 2, amiralGemisi);

            Assert.IsTrue(boardManager.HasShip(2, 1), "3,2 olmadı");
            Assert.IsFalse(boardManager.HasShip(5, 5), "5,5 hatalı yerleştirme");
        }
        [TestMethod]
        public void PlaceShip_Gemiyi_Dogru_Koordinatta_Yerlestirmeyi_Bitirir()
        {
            BoardManager boardManager = new BoardManager(10, 10);
            Target amiralGemisi = new Target(4, "east", "amiralGemisi");

            boardManager.PlaceShip(3, 2, amiralGemisi);


            Assert.IsTrue(boardManager.HasShip(2, 4), "3,5 olmadı");
            Assert.IsFalse(boardManager.HasShip(5, 5), "5,5 hatalı yerleştirme");
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

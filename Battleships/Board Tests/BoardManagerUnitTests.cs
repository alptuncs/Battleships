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
        public void PlaceShip_Gemiyi_Dogru_Koordinatta_Yerlestirmeye_Baslar()
        {
            var boardManager = new BoardManager(10, 10);
            var amiralGemisi = new Target(4, "east", "amiralGemisi");

            boardManager.PlaceShip(new Coordinate(3, 3), amiralGemisi);

            Assert.IsTrue(boardManager.HasShip(new Coordinate(3, 3)), "3,3 olmadı");
            Assert.IsFalse(boardManager.HasShip(new Coordinate(5, 5)), "5,5 hatalı yerleştirme");
        }
        [TestMethod]
        public void PlaceShip_Gemiyi_Dogru_Koordinatta_Yerlestirmeyi_Bitirir()
        {
            var boardManager = new BoardManager(10, 10);
            var amiralGemisi = new Target(4, "east", "amiralGemisi");

            boardManager.PlaceShip(new Coordinate(3, 3), amiralGemisi);

            Assert.IsTrue(boardManager.HasShip(new Coordinate(3, 5)), "3,5 olmadı");
            Assert.IsFalse(boardManager.HasShip(new Coordinate(5, 5)), "5,5 hatalı yerleştirme");
        }
        [TestMethod]

        public void Tahta_Disinda_Koordinat_Verilince_HasShip_Exception_Atar()
        {
            var boardManager = new BoardManager(10, 10);

            Assert.ThrowsException<InvalidOperationException>(() => boardManager.HasShip(new Coordinate(105, 5)));
        }
        [TestMethod]

        public void Tahta_Disinda_Koordinat_Verilince_IsHit_Exception_Atar()
        {
            var boardManager = new BoardManager(10, 10);

            Assert.ThrowsException<InvalidOperationException>(() => boardManager.IsHit(new Coordinate(105, 5)));
        }

        [TestMethod]
        public void Belirli_Sayıda_Gemiyi_Rastgele_Yerleştirir()
        {
            var boardManager = new BoardManager(10, 10);
            var amiralGemisi = new Target(4, "east", "amiralGemisi");
            var kruvazor = new Target(3, "north", "kruvazor");
            var mayinGemisi = new Target(2, "east", "mayinGemisi");
            var denizalti = new Target(1, "north", "denizalti");

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

        public void Kapasiteden_Fazla_Gemi_Eklenince_Exception_Atar()
        {
            var boardManager = new BoardManager(10, 10);
            var kruvazor = new Target(3, "north", "kruvazor");

            Assert.ThrowsException<InvalidOperationException>(() => boardManager.RandomPlaceShip(105, kruvazor));
        }

        [TestMethod]
        public void Salrıdı_Icin_Koordinat_Verilince_O_Koordinatı_Vurur()
        {
            var boardManager = new BoardManager(10, 10);
            var coordinate = new Coordinate(2, 5);
            boardManager.HitSquare(coordinate);

            Assert.IsTrue(boardManager.IsHit(coordinate));

        }
    }
}
